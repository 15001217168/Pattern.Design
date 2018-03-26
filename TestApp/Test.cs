namespace TestApp
{
    using System;
    using System.Reflection;

    public class Test
    {
        public string TestMethod(int a, string b, int c)
        {
            return (a + b + c).ToString();
        }
        public void ExecuteTest()
        {
            Test t = new Test();

            MethodInfo m = t.GetType().GetMethod("TestMethod");
            ParameterInfo[] par = m.GetParameters();
            int l = par.Length;

            object[] pa = new object[par.Length];
            for (int i = 0; i < l; i++)
            {
                object v = i;
                ParameterInfo p = par[i];
                Type type = p.ParameterType;
                pa[i] = Convert.ChangeType(v, type);
            }
            ParameterInfo returnPar = m.ReturnParameter;
            object result = m.Invoke(t, pa);

            Console.WriteLine(result);
        }

        static Func<object, object[], object> CreateDelegate(MethodInfo method)
        {
            var func = (Func<object, object>)Delegate.CreateDelegate(typeof(Func<object, object>), method);
            Func<object, object[], object> ret = (target, p) => func((Test)target);
            return ret;
        }
    }
}
