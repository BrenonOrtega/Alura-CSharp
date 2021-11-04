using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;

namespace GenericRefundsPOC
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var id = "any-dummy-aws-access-key-id";
            var key = "any-dummy-aws-secret-access-key";
            var token = "any-dummy-token";

            var credentials = new BasicAWSCredentials(id, key){  };

            var dynamoDb = new AmazonDynamoDBClient(credentials, new AmazonDynamoDBConfig() { ServiceURL = "http://localhost:8000"});

            /* await dynamoDb.CreateTableAsync(nameof(IRefund).Remove(0, 1) + "s",
                new List<KeySchemaElement>
                {
                    new KeySchemaElement(nameof(IRefund.RefundType), KeyType.HASH),
                    new KeySchemaElement(nameof(IRefund.Id), KeyType.RANGE)
                },
                new List<AttributeDefinition>
                {
                    new AttributeDefinition(nameof(IRefund.RefundType), ScalarAttributeType.S),
                    new AttributeDefinition(nameof(IRefund.Id), ScalarAttributeType.S)
                },
                new ProvisionedThroughput(5, 5));  */

            var dynamoContext = new DynamoDBContext(dynamoDb, new DynamoDBContextConfig() 
            { 
                Conversion = DynamoDBEntryConversion.V2, ConsistentRead = true , IgnoreNullValues = false, IsEmptyStringValueEnabled = true
            });

            var bankslipId = Guid.NewGuid().ToString();
            var bankslip = GetBankslip(bankslipId);

            var docId = Guid.NewGuid().ToString();
            var doc = GetDoc(docId);

            var config = new DynamoDBOperationConfig()
            {   
                OverrideTableName = "Refunds",
            };

            await dynamoContext.SaveAsync<Refund<BankslipPayment>>(bankslip, config);
            await dynamoContext.SaveAsync<Refund<DOC>>(doc, config);
        }

        private static BankslipRefund GetBankslip(string bankslipId)
        {
            return new BankslipRefund()
            {
                Id = bankslipId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                RefundInfo = new BankslipPayment()
                {
                    Amount = 1200.00M,
                    AuthorizationCode = bankslipId,
                    Barcode = new string('1', 40),
                    DocumentNumber = "111,222,333,00"
                }
            };
        }

        private static DocRefund GetDoc(string docId)
        {
            return new DocRefund()
            {
                Id = docId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                RefundInfo = new DOC(docId, 120M, new BankAccount("0001", "12323"))
            };
        }
    }
}
