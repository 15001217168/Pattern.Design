namespace _07_Pattern
{
    public class BaseEntity
    {
        public string Name { get; set; }
    }

    public class Repository<T>
    {
        public T FindBy(string name)
        {
            var sqlText = "select * from t_name where name=" + name;

            return new DataBase().Excute<T>(sqlText);
        }
    }
    public class DataBase
    {
        public T Excute<T>(string sqlText)
        {
            ///操作数据库
            return default(T);
        }
    }
}
