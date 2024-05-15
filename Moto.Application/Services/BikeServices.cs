﻿using MassTransit;
using MassTransit.Internals;
using Moto.Application.Abstractions;
using Moto.Domain.Abstractions;
using Moto.Domain.Contracts;
using Moto.Domain.Dtos.Request;
using Moto.Domain.Entities;
using Moto.Domain.Exceptions;
using Moto.Infrastructure.Base;
using Moto.Infrastructure.Repositories;
using System.IO;

namespace Moto.Application.Services
{
    public class BikeServices : IBikeServices
    {
        private readonly IUnitOfWork _uow;
        private readonly IBikeRepository _bikeRepository;
        private readonly IRentServices _rentServices;
        private readonly IPublishEndpoint _publishEndpoint;

        public BikeServices(IBikeRepository bikeRepository, IRentServices rentServices, IUnitOfWork uow, IPublishEndpoint publishEndpoint)
        {
            _bikeRepository = bikeRepository;
            _rentServices = rentServices;
            _uow = uow;
            _publishEndpoint = publishEndpoint;
        }

        public async Task CreateAsync(CreateBikeRequest request)
        {
            BikeEntity? bike = await _bikeRepository.GetByPlateAsync(request.Plate);

            if (bike != null)
                throw new BikeAlreadyRegisteredException("Já existe uma moto cadastrada para essa placa");

            BikeEntity newBike = new(request.Year, request.Plate, request.Model);

            await _bikeRepository.AddAsync(newBike);
            await _uow.Commit();

            BikeCreatedEvent bikeEvent = new(newBike.Id, newBike.Year, newBike.Plate, newBike.Model);

            await _publishEndpoint.Publish(bikeEvent);
        }

        public async Task DeleteAsync(Guid bikeId)
        {
            _ = await _bikeRepository.GetByIdAsync(bikeId) ??
                throw new BikeNotFoundException("Moto não encontrada");

            RentEntity? rent = await _rentServices.GetByBikeIdAsync(bikeId);

            if (rent is not null)
                throw new BikeRentedException("Não é possível excluir motos já alugadas");

            _bikeRepository.Delete(bikeId);
            await _uow.Commit();
        }

        public async Task<List<BikeEntity>> ListAsync(string plate)
        {
            if (string.IsNullOrEmpty(plate))
                return await _bikeRepository.GetAllAsync();

            BikeEntity? bike = await _bikeRepository.GetByPlateAsync(plate) ??
                throw new BikeNotFoundException("Moto não encontrada");

            List<BikeEntity> bikes = [bike];

            return bikes;
        }

        public async Task UpdateAsync(Guid id, string plate)
        {
            var bike = await _bikeRepository.GetByIdAsync(id) ??
                throw new BikeNotFoundException("Moto não encontrada");

            bike.UpdatePlate(plate);

            await _uow.Commit();
        }
    }
}