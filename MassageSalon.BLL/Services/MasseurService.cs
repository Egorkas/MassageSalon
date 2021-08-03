﻿using AutoMapper;
using MassageSalon.BLL.Interfaces;
using MassageSalon.DAL.Common.Entities;
using MassageSalon.DAL.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Services
{
    public class MasseurService : IMasseurService
    {
        private readonly IGenericRepository<Masseur> _repository;

        public MasseurService(IGenericRepository<Masseur> repository)
        {
            _repository = repository;
        }

        public void CreateMasseur(Masseur masseur) =>
            _repository.Create(masseur);

        public IEnumerable<Masseur> GetAll() =>
            _repository.GetAll();

        public Masseur GetMasseurById(int? id) =>
            _repository.Get(id);

        public void UpdateMasseur(Masseur masseur) =>
            _repository.Update(masseur);
    }
}
