using AdoptionCenter.DataAccess.EF.Context;
using AdoptionCenter.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdoptionCenter.DataAccess.EF.Repositories
{
    public class PetRepository
    {
        private AdoptionWebsiteContext _dbContext;

        public PetRepository(AdoptionWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(Pet pet)
        {

            _dbContext.Add(pet);
            _dbContext.SaveChanges();

            return pet.PetId;
        }

        public int Update(Pet pet)
        {
            Pet existingPet = _dbContext.Pets.Find(pet.PetId);

            existingPet.PetName = pet.PetName;
            existingPet.PetBreed = pet.PetBreed;
            existingPet.PetAge = pet.PetAge;
            existingPet.PetDesc = pet.PetDesc;

            _dbContext.SaveChanges();
            return existingPet.PetId;
        }

        public bool Delete(int petId)
        {
            Pet pet = _dbContext.Pets.Find(petId);
            _dbContext.Pets.Remove(pet);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Pet> GetAllPets()
        {
            List<Pet> PetList = _dbContext.Pets.ToList();
            return PetList;
        }

        public Pet GetPetByID(int petId)
        {
            Pet pet = _dbContext.Pets.Find(petId);

            return pet;
        }
    }
    
}
