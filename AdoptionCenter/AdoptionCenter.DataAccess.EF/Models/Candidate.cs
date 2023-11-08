using System;
using System.Collections.Generic;

namespace AdoptionCenter.DataAccess.EF.Models;

public partial class Candidate
{
    public Candidate(int candidateId, string candidateName, string candidateLastname, string candidateJob, string candidateEmail, string candidatePhone)
    {
        CandidateId = candidateId;
        CandidateName = candidateName;
        CandidateLastName = candidateLastname;
        CandidateJob = candidateJob;
        CandidateEmail = candidateEmail;
        CandidatePhoneNumber = candidatePhone;

    }

    public Candidate()
    {

    }

    public int CandidateId { get; set; }

    public string CandidateName { get; set; } = null!;

    public string CandidateLastName { get; set; } = null!;

    public string CandidateJob { get; set; } = null!;

    public string CandidateEmail { get; set; } = null!;

    public string CandidatePhoneNumber { get; set; } = null!;
}
