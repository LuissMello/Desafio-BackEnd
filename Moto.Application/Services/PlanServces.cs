using FluentValidation;
using FluentValidation.Results;
using Moto.Application.Abstractions;
using Moto.Domain.Abstractions;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Dtos.Response;
using Moto.Domain.Entities;
using Moto.Domain.Exceptions;
using Moto.Infrastructure.Base;
using Moto.Infrastructure.Repositories;
using System;

namespace Moto.Application.Services
{
    public class PlanServices : IPlanServices
    {
        private readonly IUnitOfWork _uow;
        private readonly IPlanRepository _planRepository;
        private readonly IValidator<PlanEntity> _validator;

        public PlanServices(IPlanRepository planRepository, IUnitOfWork uow, IValidator<PlanEntity> validator)
        {
            _planRepository = planRepository;
            _uow = uow;
            _validator = validator;
        }

        public async Task<PlanEntity> CreateAsync(CreatePlanRequest request)
        {
            PlanEntity? plan = await _planRepository.GetByDaysAsync(request.Days);

            if (plan is not null)
                throw new PlanAlreadyRegisteredException("Esse plano já existe");

            PlanEntity newPlan = new(request.Days, request.Price, request.Fee);

            ValidationResult result = await _validator.ValidateAsync(newPlan);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);
            
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

            ValidationResult result = await _validator.ValidateAsync(plan);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            await _uow.Commit();

            return plan;
        }
    }
}
