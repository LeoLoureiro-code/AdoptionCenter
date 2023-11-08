using System;
using System.Collections.Generic;

namespace AdoptionCenter.DataAccess.EF.Models;

public partial class Pet
{
    public Pet(int petId, string petName, string petBreed, int petAge, string petDesc, string petImage)
    {
        PetId = petId;
        PetName = petName;
        PetBreed = petBreed;
        PetAge = petAge;
        PetDesc = petDesc;

    }

    public Pet()
    {

    }

    public int PetId { get; set; }

    public string PetName { get; set; } = null!;

    public string PetBreed { get; set; } = null!;

    public int PetAge { get; set; }

    public string PetDesc { get; set; } = null!;
}
