﻿using FluentValidation;
using FluentValidation.Results;
using Moto.Application.Abstractions;
using Moto.Domain.Abstractions;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Entities;
using Moto.Domain.Exceptions;
using Moto.Infrastructure.Base;

namespace Moto.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        private readonly IValidator<UserEntity> _validator;
        public UserServices(IUserRepository userRepository, IUnitOfWork uow, IValidator<UserEntity> validator)
        {
            _userRepository = userRepository;
            _uow = uow;
            _validator = validator;
        }

        public async Task<List<UserEntity>> GetAllAsync()
            => await _userRepository.GetAllAsync();

        public async Task<UserEntity?> GetByCnpjAsync(string cnpj)
            => await _userRepository.GetByCnpjAsync(cnpj);

        public async Task<UserEntity?> GetByIdAsync(Guid userId)
            => await _userRepository.GetByIdAsync(userId);

        public async Task<UserEntity> ResisterAsync(RegisterUserRequest request)
        {
            UserEntity? user = await _userRepository.GetByCnpjAsync(request.Cnpj);

            if (user != null)
                throw new UserAlreadyRegisteredException("Usuário já cadastrado para esse Cnpj");

            user = await _userRepository.GetByCnhAsync(request.Cnh);

            if (user != null)
                throw new UserAlreadyRegisteredException("Usuário já cadastrado para essa Cnh");

            UserEntity newUser = new(request.Name, request.Cnpj, request.BirthDate, request.Cnh, request.CnhType, request.Role, request.Password);

            ValidationResult result = await _validator.ValidateAsync(newUser);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            if (!newUser.IsValidCnh())
                throw new InvalidDocumentTypeException("Tipo de carteira incompativel");
            
            await _userRepository.AddAsync(newUser);
            await _uow.Commit();

            return newUser;
        }
    }
}
