using AdoptionCenter.DataAccess.EF.Context;
using AdoptionCenter.DataAccess.EF.Repositories;
using AdoptionCenter.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptionCenter.Models
{
    public class PetsViewModel
    {
        private PetRepository _repo;

        public List<Pet> PetsList { get; set; }

        public Pet CurrentPet { get; set; }

        public bool IsActionSuccess { get; set; }

        public string ActionMessage { get; set; }

        public PetsViewModel(AdoptionWebsiteContext context)
        {
            _repo = new PetRepository(context);
            PetsList = GetAllPets();
            CurrentPet = PetsList.FirstOrDefault();
        }

        public PetsViewModel(AdoptionWebsiteContext context, int petId)
        {
            _repo = new PetRepository(context);
            PetsList = GetAllPets();

            if (petId > 0)
            {
                CurrentPet = GetPet(petId);
            }
            else
            {
                CurrentPet = new Pet();
            }
        }

        public void SavePet(Pet pet)
        {
            if (pet.PetId > 0)
            {
                _repo.Update(pet);
            }
            else
            {
                pet.PetId = _repo.Create(pet);
            }

            PetsList = GetAllPets();
            CurrentPet = GetPet(pet.PetId);
        }

        public void RemovePet(int petId)
        {
            _repo.Delete(petId);
            PetsList = GetAllPets();
            CurrentPet = PetsList.FirstOrDefault();
        }

        public List<Pet> GetAllPets()
        {
            return _repo.GetAllPets();
        }

        public Pet GetPet(int petId)
        {
            return _repo.GetPetByID(petId);
        }
    }
}
