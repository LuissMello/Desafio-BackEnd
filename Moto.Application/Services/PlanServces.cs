using Moto.Application.Abstractions;
using Moto.Domain.Abstractions;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Dtos.Response;
using Moto.Domain.Entities;
using Moto.Domain.Exceptions;
using Moto.Infrastructure.Base;
using Moto.Infrastructure.Repositories;

namespace Moto.Application.Services
{
    public class PlanServices : IPlanServices
    {
        private readonly IUnitOfWork _uow;
        private readonly IPlanRepository _planRepository;

        public PlanServices(IPlanRepository planRepository, IUnitOfWork uow)
        {
            _planRepository = planRepository;
            _uow = uow;
        }

        public async Task<PlanEntity> CreateAsync(CreatePlanRequest request)
        {
            PlanEntity? plan = await _planRepository.GetByDaysAsync(request.Days);

            if (plan is not null)
                throw new PlanAlreadyRegisteredException("Esse plano já existe");

            PlanEntity newPlan = new(request.Days, request.Price, request.Fee);

            await _planRepository.AddAsync(newPlan);
            await _uow.Commit();

            return newPlan;
        }

        public async Task Delete(Guid planId)
        {
            _ = await _planRepository.GetByIdAsync(planId) ??
                throw new PlanNotFoundException("Esse plano não existe");

            _planRepository.Delete(planId);
            await _uow.Commit();
        }

        public async Task<List<PlanEntity>> ListAllAsync()
            => await _planRepository.GetAllAsync();

        public async Task<PlanEntity> UpdateAsync(Guid planId, UpdatePlanRequest request)
        {
            PlanEntity plan = await _planRepository.GetByIdAsync(planId) ??
                throw new PlanNotFoundException("Esse plano não existe");

            PlanEntity? existsPlan = await _planRepository.GetByDaysAsync(request.Days);

            if (existsPlan is not null)
                throw new PlanAlreadyRegisteredException("Esse plano já existe");

            plan.Update(request.Days, request.Price, request.Fee);

            await _uow.Commit();

            return plan;
        }
    }
}
