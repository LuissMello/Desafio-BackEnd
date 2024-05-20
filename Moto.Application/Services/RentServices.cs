using FluentValidation;
using FluentValidation.Results;
using Moto.Application.Abstractions;
using Moto.Domain.Abstractions;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Dtos.Response;
using Moto.Domain.Entities;
using Moto.Domain.Exceptions;
using Moto.Infrastructure.Base;

namespace Moto.Application.Services
{
    public class RentServices : IRentServices
    {
        private readonly IRentRepository _rentRepository;
        private readonly IBikeRepository _bikeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPlanRepository _planRepository;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<RentEntity> _validator;

        public RentServices(IRentRepository rentRepository, IBikeRepository bikeRepository, IUserRepository userRepository, IUnitOfWork uow, IPlanRepository planRepository, IValidator<RentEntity> validator)
        {
            _rentRepository = rentRepository;
            _bikeRepository = bikeRepository;
            _userRepository = userRepository;
            _planRepository = planRepository;
            _validator = validator;
            _uow = uow;
        }

        public async Task<RentEntity> CreateAsync(CreateRentRequest request)
        {
            BikeEntity bike = await _bikeRepository.GetByIdAsync(request.BikeId)
                ?? throw new BikeNotFoundException("A moto informada não foi encontrada");

            UserEntity user = await _userRepository.GetByIdAsync(request.UserId)
                ?? throw new UserNotFoundException("O usuário informado não foi encontrada");

            PlanEntity plan = await _planRepository.GetByIdAsync(request.PlanId)
                ?? throw new PlanNotFoundException("O plano informado não foi encontrada");

            RentEntity? rentExists = await _rentRepository.GetByBikeIdAsync(request.BikeId);

            if (rentExists is not null && rentExists.PreviewEndDate >= DateTime.Now)
                throw new BikeAlreadyRentedException("A moto informada já possui locação");

            RentEntity newRent = new(user, bike, plan);

            ValidationResult result = await _validator.ValidateAsync(newRent);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (!newRent.CanRent())
                throw new InvalidDocumentTypeException("Tipo de carteira incompativel");

            await _rentRepository.AddAsync(newRent);
            await _uow.Commit();

            return newRent;
        }

        public async Task<FinishRentResponse> FinishAsync(FinishRentRequest request)
        {
            RentEntity rent = await _rentRepository.GetByIdAsync(request.RentId)
                ?? throw new RentNotFoundException("A locação informada não foi encontrada");

            decimal price = rent.CalculatePrice(request.Date) + rent.CalculateFine(request.Date);

            await _uow.Commit();

            return new FinishRentResponse(price, rent.StartDate, rent.PreviewEndDate);
        }

        public async Task<RentEntity?> GetByBikeIdAsync(Guid bikeId)
            => await _rentRepository.GetByBikeIdAsync(bikeId);
    }
}
