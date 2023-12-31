﻿using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal_API.Models;

namespace StudentAdminPortal_API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        //Method declaration to fetch a specific student info.
        Task<Student> GetStudent(Guid studentId);
        Task<List<Gender>> GetAllGenders();
        Task<Student> UpdateStudentDetails(Guid studentId, DomainModels.RequestStudent requestStudentDetails);
        Task<Student> DeleteAStudent(Guid studentId);
        Task<Student> CreateNewStudent(Student createStudentDetails);
        Task<Student> UploadImageURL(Guid studentId, string profileImageURL);
    }
}
