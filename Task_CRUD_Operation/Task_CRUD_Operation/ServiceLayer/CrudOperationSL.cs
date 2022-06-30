using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_CRUD_Operation.CommonLayer.Model;
using Task_CRUD_Operation.RepositoryLayer;

namespace Task_CRUD_Operation.ServiceLayer
{
    public class CrudOperationSL : ICrudOperationSL
    {


        public readonly ICrudOperationRL _crudOperationRL;
        public CrudOperationSL(ICrudOperationRL crudOperationRL)
        {
            _crudOperationRL = crudOperationRL;
        }

        //Servie layer is used for Transaction or Business
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            return await _crudOperationRL.CreateRecord(request);
        }

        

        public async Task<ReadInformationResponse> ReadInformation()
        {
            return await _crudOperationRL.ReadInformation();
        }

        public async Task<UpdateRecordResponse> UpdateInformation(UpdateRecordRequest request)
        {
            return await _crudOperationRL.UpdateInformation(request);
        }
        public async Task<DeleteRecordResponse> DeleteInformation(DeleteRecordRequest request)
        {
            return await _crudOperationRL.DeleteInformation(request);
        }

    }
}
