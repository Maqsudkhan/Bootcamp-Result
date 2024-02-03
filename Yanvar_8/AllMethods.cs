using System.Text.Json;

namespace HmJson
{
    public  class MethodsAll
    {
        string paTH = "D:\\BFN\\.Net\\C#\\Yanvar_8\\bin\\Debug\\net8.0";

        public List<T> AllReadEntitys<T>()
        {
            string fullpath = Path.Combine(paTH, typeof(T).FullName + ".json");

            string jsondata;

            if (!File.Exists(fullpath))
            {
                return new List<T>();
            }
            using (StreamReader reader = new StreamReader(fullpath))
            {
                jsondata = reader.ReadToEnd();
            }
            List<T> myDataList;
            try
            {
                myDataList = JsonSerializer.Deserialize<List<T>>(jsondata);
            }
            catch
            {
                return new List<T>();
            }
            return myDataList;
        }
        public  void Add<T>(T entity)
        {
            var filename=typeof(T).FullName;

            var entitys = AllReadEntitys<T>();

            var id = typeof(T).GetProperty("Id");

            var idValue = id.GetValue(entity);

            foreach (var item in entitys)
            {
                var idItem = typeof(T).GetProperty("Id");

                var idValueItem = idItem.GetValue(item);

                if (Convert.ToInt32(idValue) == Convert.ToInt32(idValueItem) )
                {
                    return;
                }
            }
            entitys.Add(entity);

            AllWriteEntitys<T>(entitys);
        }


        public void Update<T>(int UpdateId, T entity)
        {
            if (entity == null) { return; }

            var localentitys = AllReadEntitys<T>();

            for (int i = 0; i < localentitys.Count; i++)
            {
                var idItem = typeof(T).GetProperty("Id");

                var idValueItem = idItem.GetValue(localentitys[i]);

                if (UpdateId == Convert.ToInt32(idValueItem))
                {
                    localentitys[i] = entity;

                    AllWriteEntitys<T>(localentitys);

                    GetAll<T>();

                    return;
                }
            }
            Console.WriteLine("Bu Id li odam yuq");
        }
        internal void UpData<T>(int v, T person)
        {
            throw new NotImplementedException();
        }


        public void AllWriteEntitys<T>(List<T> entitys)
        {
            var jsondata = JsonSerializer.Serialize(entitys);

            using(StreamWriter sw= new StreamWriter(Path.Combine(paTH, typeof(T).FullName + ".json"))) 
            {
                sw.Write(jsondata);
            }
        }



        public void GetAll<T>()
        {
            string fullpath = Path.Combine(paTH, typeof(T).FullName+".json"); 

            if(File.Exists(fullpath))
            {
                string jsondata;

                using(StreamReader reader= new StreamReader(fullpath))
                {
                    jsondata= reader.ReadToEnd();
                }
                Console.WriteLine(jsondata);
            }
            else
            {
                Console.WriteLine($"{typeof(T).FullName} bu fayl yuq");
            }
        }


        public void GetById<T>(int Id)
        {
            var localentitys = AllReadEntitys<T>();

            foreach (var item in localentitys)
            {
                var idItem = typeof(T).GetProperty("Id");

                var idValueItem = idItem.GetValue(item);

                if (Id == Convert.ToInt32(idValueItem))
                {
                    var props = typeof(T).GetProperties();

                    foreach (var prop in props) 

                    {
                        var value = prop.GetValue(item);

                        Console.Write(value+ " ");
                    }
                    return;
                }
            }
        }




        public void Delete<T>(int Id)
        {
            var localentitys = AllReadEntitys<T>();

            foreach (var item in localentitys)
            {
                var idItem = typeof(T).GetProperty("Id");

                var idValueItem = idItem.GetValue(item);

                if (Id == Convert.ToInt32(idValueItem))

                {
                    localentitys.Remove(item);

                    AllWriteEntitys<T>(localentitys);


                    GetAll<T>();

                    return;
                }
            }
            Console.WriteLine("Bu Id li odam yuq");
        }


    }
}





