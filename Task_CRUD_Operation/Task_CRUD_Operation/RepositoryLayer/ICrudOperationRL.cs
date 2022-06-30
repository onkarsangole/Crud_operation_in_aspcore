using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_CRUD_Operation.CommonLayer.Model;

namespace Task_CRUD_Operation.RepositoryLayer
{
    public interface ICrudOperationRL
    {
        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);
        public Task<ReadInformationResponse> ReadInformation();

        public Task<UpdateRecordResponse> UpdateInformation(UpdateRecordRequest request);

        public Task<DeleteRecordResponse> DeleteInformation(DeleteRecordRequest request);
    }
}
