
namespace _13_Family_Tree
{
    using System.Collections.Generic;
    using System.Linq;

    public class RecordsHelper
    {
        public static bool IsChildren(List<Record> records, Record record, Person mainPerson, out Record resultRecord)
        {
            resultRecord = new Record();

            if (record.version == RecordVersion.v1)
            {
                if (record.left == mainPerson.Name)
                {
                    resultRecord.left = record.right;
                    resultRecord.right = GetRecordDate(records, resultRecord);
                    return true;
                }
            }
            else if (record.version == RecordVersion.v2)
            {
                if (record.left == mainPerson.BirthDate)
                {
                    resultRecord.left = record.right;
                    resultRecord.right = GetRecordDate(records, resultRecord);
                    return true;
                }
            }
            else if (record.version == RecordVersion.v3)
            {
                if (record.left == mainPerson.Name)
                {
                    resultRecord.right = record.right;
                    resultRecord.left = GetRecordName(records, resultRecord);
                    return true;
                }
            }
            else if (record.version == RecordVersion.v4)
            {
                if (record.left == mainPerson.BirthDate)
                {
                    resultRecord.right = record.right;
                    resultRecord.left = GetRecordName(records, resultRecord);
                    return true;
                }
            }
            else if (record.version == RecordVersion.v5)
            {
                if (records.Any(r => r.right == record.left && r.left == mainPerson.Name) || // name - name
                    records.Any(r => r.right == record.left && r.left == mainPerson.BirthDate) || // date - name
                    records.Any(r => r.right == record.right && r.left == mainPerson.Name && r.version != RecordVersion.v5) || // name - date
                    records.Any(r => r.right == record.right && r.left == mainPerson.BirthDate)) // date - date
                {
                    resultRecord = record;
                    return true;
                }
            }
            return false;
        }

        public static bool IsParent(List<Record> records, Record record, Person mainPerson, out Record resultRecord)
        {
            resultRecord = new Record();

            if (record.version == RecordVersion.v1)
            {
                if (record.right == mainPerson.Name)
                {
                    resultRecord.left = record.left;
                    resultRecord.right = GetRecordDate(records, resultRecord);
                    return true;
                }
            }
            else if (record.version == RecordVersion.v2)
            {
                if (record.right == mainPerson.BirthDate)
                {
                    resultRecord.left = record.left;
                    resultRecord.right = GetRecordDate(records, resultRecord);
                    return true;
                }
            }
            else if (record.version == RecordVersion.v3)
            {
                if (record.right == mainPerson.Name)
                {
                    resultRecord.right = record.left;
                    resultRecord.left = GetRecordName(records, resultRecord);
                    return true;
                }
            }
            else if (record.version == RecordVersion.v4)
            {
                if (record.right == mainPerson.BirthDate)
                {
                    resultRecord.right = record.left;
                    resultRecord.left = GetRecordName(records, resultRecord);
                    return true;
                }
            }
            else if (record.version == RecordVersion.v5)
            {
                if (records.Any(r => r.left == record.left && r.right == mainPerson.Name) || // name - name
                    records.Any(r => r.left == record.left && r.right == mainPerson.BirthDate && r.version!=RecordVersion.v5) || // name - date
                    records.Any(r => r.left == record.right && r.right == mainPerson.Name) || // date - name
                    records.Any(r => r.left == record.right && r.right == mainPerson.BirthDate)) // date - date
                {
                    resultRecord = record;
                    return true;
                }
            }
            return false;
        }

        private static string GetRecordName(List<Record> records, Record recordWithNoName)
        {
            string recordName = records.Where(r => r.version == RecordVersion.v5 && r.right == recordWithNoName.right).FirstOrDefault().left;
            return recordName;
        }

        private static string GetRecordDate(List<Record> records, Record recordWithNoDate)
        {
            string recordDate = records.Where(r => r.version == RecordVersion.v5 && r.left == recordWithNoDate.left).FirstOrDefault().right;
            return recordDate;
        }
    }
}
