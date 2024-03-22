
using H5ServerSide_ToDoList.Data;
using H5ServerSide_ToDoList.Data.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace H5ServerSide_ToDoList.Codes.Services
{
    public class CPRService : ICPRService
    {
        
        private readonly DataDBContext _dataDbContext;
        private readonly IHashingService _hashingService;


        public CPRService(DataDBContext dataDBContext, IHashingService hashingService, IAsymmetricEncryptionService asymmetricEncryptionService)
        {
            _dataDbContext = dataDBContext;
            _hashingService = hashingService;
        }

        public async Task AddCPR(ApplicationUser user, string cpr)
        {
            if(user != null)
            {
                AsymmetricEncryptionService encryption = new AsymmetricEncryptionService();
                
                var hashedCpr = _hashingService.BCryptHash(cpr, ReturnType.String);

                _dataDbContext.CPRs.Add(new CPR { CPR_number = hashedCpr, Name = user.UserName, Id = Guid.Parse(user.Id), PrivateKey = encryption._privateKey, PublicKey = encryption._publicKey });

                await _dataDbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException("User not found.");
            }
        }

        public async Task<bool> CPRExist(ApplicationUser user)
        {
            return await _dataDbContext.CPRs.AnyAsync(cpr => cpr.Id == Guid.Parse(user.Id));
        }

        public async Task<bool> ValidateCPR(ApplicationUser user, string CprString)
        {
            string hashedCpr = (await _dataDbContext.CPRs.FirstOrDefaultAsync(cpr => cpr.Id == Guid.Parse(user.Id))).CPR_number;

            return _hashingService.BCryptHashValidate(CprString, hashedCpr);
        }


    }
}
