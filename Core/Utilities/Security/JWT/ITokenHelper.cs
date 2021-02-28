using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //Token üretecek mekanizmamız burasıdır.
        // kim için üretecek bu Tokeni ve hangi yetkileri olacağını bildiren sistem 
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims); 
    }
}
