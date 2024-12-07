namespace restApiTuto.DB; 

 public record Record
 {
   public int Id {get; set;} 
   public string ? Name { get; set; }
 }

 public class RecordDb
 {
   private static List<Record> _records = new List<Record>()
   {
     new Record{ Id=1, Name="Montemagno, Pizza shaped like a great mountain" },
     new Record{ Id=2, Name="The Galloway, Pizza shaped like a submarine, silent but deadly"},
     new Record{ Id=3, Name="The Noring, Pizza shaped like a Viking helmet, where's the mead"} 
   };

   public static List<Record> GetRecords() 
   {
     return _records;
   } 

   public static Record ? GetRecord(int id) 
   {
     return _records.SingleOrDefault(record => record.Id == id);
   } 

   public static Record CreateRecord(Record record) 
   {
     _records.Add(record);
     return record;
   }

   public static Record UpdateRecord(Record update) 
   {
     _records = _records.Select(record =>
     {
       if (record.Id == update.Id)
       {
         record.Name = update.Name;
       }
       return record;
     }).ToList();
     return update;
   }

   public static void RemoveRecord(int id)
   {
     _records = _records.FindAll(record => record.Id != id).ToList();
   }
 }