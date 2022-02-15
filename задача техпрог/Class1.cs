using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace задача_техпрог
{
    internal class Class1
    {
        public static Random random = new Random();

        struct Store
        {
            public string title_store;
            public Loyality loyality;
            public Stoika[] stoika;

            public Store(string title_store, Loyality loyality, Stoika[] stoika)
            {
                this.title_store = title_store;
                this.loyality = loyality;
                this.stoika = stoika;
            }
        }

        enum Loyality
        {
            Base,
            Silver,
            Gold
        }

        enum Clas
        {
            Economy,
            Standart,
            Premium
        }

        struct Stoika
        {
            public string title_st;
            public Tovar[] tovars;

            public Stoika(string title_st, Tovar[] tovars)
            {
                this.title_st = title_st;
                this.tovars = tovars;
            }
        }

        struct Tovar
        {
            public string title_tovar;
            public string type;
            public Clas clas;
            public Params[] parametry;
            public Csena csena;

            public Tovar(string title_tovar, string type, Clas clas, Params[] parametry, Csena csena)
            {
                this.title_tovar = title_tovar;
                this.type = type;
                this.clas = clas;
                this.parametry = parametry;
                this.csena = csena;
            }
        }

        struct Params
        {
            public string param;

            public Params(string param)
            {
                this.param = param;
            }
        }

        
        struct Csena
        {
            public Base_csena baseCsena;
            public Opt_csena optCsena;

            public Csena(Base_csena baseCsena, Opt_csena optCsena)
            {
                this.baseCsena = baseCsena;
                this.optCsena = optCsena;
            }
        }

        struct Base_csena
        {
            public Client client_base;
            public Corporate corporate_base;

            public Base_csena(Client client_base, Corporate corporate_base)
            {
                this.client_base = client_base;
                this.corporate_base = corporate_base;
            }
        }
        
        struct Opt_csena
        {
            public Client client_opt;
            public Corporate corporate_opt;

            public Opt_csena(Client client_opt, Corporate corporate_opt)
            {
                this.client_opt = client_opt;
                this.corporate_opt = corporate_opt;
            }
        }

        struct Client
        {
            public double base_csena;
            public double opt_csena_10;
            public double opy_csena_100;
            public double opt_csena_1000;

            public Client(double baseCsena, double optCsena10, double opyCsena100, double optCsena1000)
            {
                this.base_csena = baseCsena;
                this.opt_csena_10 = optCsena10;
                this.opy_csena_100 = opyCsena100;
                this.opt_csena_1000 = optCsena1000;
            }
        }
        
        struct Corporate
        {
            public double corp_csena;
            public double opt_csena_10; 
            public double opt_csena_100;
            public double opt_csena_1000;

            public Corporate (double corpCsena, double optCsena10, double optCsena100, double optCsena1000)
            {
                this.corp_csena = corpCsena;
                this.opt_csena_10 = optCsena10;
                this.opt_csena_100 = optCsena100;
                this.opt_csena_1000 = optCsena1000;
            }
        }
        
        public static void Main(string[] args)
        {
            task1();
        }

        static void task1()
        {
            int store_num = random.Next(1, 4);
            Store[] stores = new Store[store_num];

            for (int i = 0; i < stores.Length; i++)
            {
                stores[i] = GenStore();
            }
            Summator(ref stores);
            outPut(stores);
        }

        static void dfg(ref Store[] store)
        {
            for (int i = 0; i < store.Length; i++)
            {
                for (int j = 0; j < store[i].stoika.Length; j++)
                {
                    for (int k = 0; k < store[i].stoika[j].tovars.Length; k++)
                    {
                        double csena = GenrandDouble(store);
                        double skidka_client_base = 0;
                        double skidka_korp_base = 0;
                        double skidka_client_opt = 0;
                        double skidka_korp_opt = 0;
                        double skidka_loyal = 0;
                        if (store[i].stoika[j].tovars[k].clas == Clas.Economy)
                        {
                            skidka_client_base = 0.95;
                            skidka_korp_base = 0.98;
                            skidka_client_opt = 0.94;
                            skidka_korp_opt = 0.97;
                        }
                        
                        if (store[i].stoika[j].tovars[k].clas == Clas.Standart)
                        {
                            skidka_client_base = 0.93;
                            skidka_korp_base = 0.96;
                            skidka_client_opt = 0.93;
                            skidka_korp_opt = 0.95;
                        }
                        
                        if (store[i].stoika[j].tovars[k].clas == Clas.Premium)
                        {
                            skidka_client_base = 0.9;
                            skidka_korp_base = 0.95;
                            skidka_client_opt = 0.89;
                            skidka_korp_opt = 0.94;
                        }

                        if (store[i].loyality == Loyality.Base) {skidka_loyal = 0.95;}
                        if (store[i].loyality == Loyality.Silver) {skidka_loyal = 0.9;}
                        if (store[i].loyality == Loyality.Gold) {skidka_loyal = 0.85;}
                        
                        store[i].stoika[j].tovars[k].csena.baseCsena.client_base.base_csena = csena*skidka_client_base*skidka_loyal;
                        store[i].stoika[j].tovars[k].csena.baseCsena.corporate_base.corp_csena = csena*skidka_korp_base*skidka_loyal;
                        store[i].stoika[j].tovars[k].csena.optCsena.client_opt.opt_csena_10 = 
                            csena * 10 * skidka_client_opt * 0.98*skidka_loyal;
                        store[i].stoika[j].tovars[k].csena.optCsena.client_opt.opy_csena_100 =
                            csena * 100 * skidka_client_opt* 0.97 * skidka_loyal;
                        store[i].stoika[j].tovars[k].csena.optCsena.client_opt.opt_csena_1000 =
                            csena * 1000 * skidka_client_opt* 0.95 * skidka_loyal;
                        store[i].stoika[j].tovars[k].csena.optCsena.corporate_opt.opt_csena_10 =
                            csena * 10 * skidka_korp_opt * 0.98 * skidka_loyal;
                        store[i].stoika[j].tovars[k].csena.optCsena.corporate_opt.opt_csena_100 =
                            csena * 100 * skidka_korp_opt* 0.97 * skidka_loyal;
                        store[i].stoika[j].tovars[k].csena.optCsena.corporate_opt.opt_csena_1000 =
                            csena * 1000 * skidka_korp_opt* 0.95 * skidka_loyal;
                    }
                }
            }
        }
        
        static void Summator(ref Store[] store)
        {
            //task_base_client(ref store);
            dfg(ref store);
        }

        static void outPut(Store[] stores)
        {
            for (int i = 0; i < stores.Length; i++)
            {
                Console.WriteLine($"Магазин: {stores[i].title_store}");
                Console.WriteLine($"\tТип лояльности: {stores[i].loyality}");
                foreach (Stoika stoikas in stores[i].stoika)
                {
                    Console.WriteLine($"\tСтойка: {stoikas.title_st}");
                    foreach (Tovar tovar in stoikas.tovars)
                    {
                        Console.WriteLine($"\t\tToвар: {tovar.title_tovar}");
                        Console.WriteLine($"\t\t\tТип: {tovar.type}");
                        Console.WriteLine($"\t\t\tКласс: {tovar.clas}");
                        Console.WriteLine("\t\t\tПараметры");
                        foreach (Params par in tovar.parametry)
                        {
                            Console.WriteLine($"\t\t\t\tПараметр: {par.param}");
                        }

                        Console.WriteLine("\t\t\tЦена:");
                        Console.WriteLine("\t\t\t\tБазовая:");
                        Console.WriteLine($"\t\t\t\t\tКлиентская: {tovar.csena.baseCsena.client_base.base_csena}");
                        Console.WriteLine($"\t\t\t\t\tКорпоративна: {tovar.csena.baseCsena.corporate_base.corp_csena}");
                        Console.WriteLine("\t\t\t\tОптовая:");
                        Console.WriteLine("\t\t\t\t\tКлиентская:");
                        Console.WriteLine($"\t\t\t\t\t\t10: {tovar.csena.optCsena.client_opt.opt_csena_10}");
                        Console.WriteLine($"\t\t\t\t\t\t100: {tovar.csena.optCsena.client_opt.opy_csena_100}");
                        Console.WriteLine($"\t\t\t\t\t\t1000: {tovar.csena.optCsena.client_opt.opt_csena_1000}");
                        Console.WriteLine($"\t\t\t\t\tКорпоративная:");
                        Console.WriteLine($"\t\t\t\t\t\t10: {tovar.csena.optCsena.corporate_opt.opt_csena_10}");
                        Console.WriteLine($"\t\t\t\t\t\t100: {tovar.csena.optCsena.corporate_opt.opt_csena_100}");
                        Console.WriteLine($"\t\t\t\t\t\t1000: {tovar.csena.optCsena.corporate_opt.opt_csena_1000}");
                    }
                }
            }
        }

        static Store GenStore()
        {
            string title_store = genType(4, 7);
            
            Loyality[] loyalities = {Loyality.Base, Loyality.Silver, Loyality.Gold};
            int d = random.Next(0, 3);
            Loyality loyality = loyalities[d];

            int h = random.Next(1, 3);
            Stoika[] stoikas = new Stoika[h];
            for (int i = 0; i <stoikas.Length; i++)
            {
                stoikas[i] = genStoika();
            }

            Store store = new Store(title_store, loyality, stoikas);
            return store;
        }

        static Stoika genStoika()
        {
            string title = "";
            title += Convert.ToString(random.Next(1, 10));

            int num_tovar = random.Next(1, 3);
            Tovar[] tovars = new Tovar[num_tovar];
            for (int i = 0; i < tovars.Length; i++)
            {
                tovars[i] = genTovar();
            }

            Stoika stoika = new Stoika(title, tovars);
            return stoika;
        }

        static Tovar genTovar()
        {
            string title_tovar = genType(4, 7);
            string type = genType(4, 7);
            
            Clas[] clasArray = {Clas.Economy, Clas.Standart, Clas.Premium};
            int rand_class = random.Next(0, 3);
            Clas clas = clasArray[rand_class];

            int rand_params = random.Next(3, 5);
            Params[] paramsArray = new Params[rand_params];
            for (int i = 0; i < paramsArray.Length; i++)
            {
                paramsArray[i] = genParams();
            }

            Csena csena = genCsena();

            Tovar tovar = new Tovar(title_tovar, type, clas, paramsArray, csena);
            return tovar;
        }

        static Params genParams()
        {
            string title = genType(4, 7);
            Params param = new Params(title);
            return param;
        }

        static Csena genCsena()
        {
            Base_csena baseCsena = genBase_csena();
            Opt_csena optCsena = genOpt_csena();
            Csena csena = new Csena(baseCsena, optCsena);
            return csena;
        }

        static Base_csena genBase_csena()
        {
            Client client_base = genClient_Base();
            Corporate corporate_base = genCorporate_base();
            Base_csena base_csena = new Base_csena(client_base, corporate_base);
            return base_csena;
        }

        static Opt_csena genOpt_csena()
        {
            Client client_opt = genClient_Opt();
            Corporate corporate_opt = genCorporate_Opt();
            Opt_csena opt_csena = new Opt_csena(client_opt, corporate_opt);
            return opt_csena;
        }

        static Client genClient_Base()
        {
            double base_csena = 0;
            Client client_base = new Client(base_csena, 0, 0, 0);
            return client_base;
        }

        static Corporate genCorporate_base()
        {
            double corp_csena = 0;
            Corporate corp = new Corporate(corp_csena,0, 0, 0);
            return corp;
        }

        static Client genClient_Opt()
        {
            double optcsena10 = 0;
            double optcsena100 = 0;
            double optcsena1000 = 0;
            Client client_opt = new Client(0, optcsena10, optcsena100, optcsena1000);
            return client_opt;
        }

        static Corporate genCorporate_Opt()
        {
            double optcsena10 = 0;
            double optcsena100 = 0;
            double optcsena1000 = 0;
            Corporate corp_opt = new Corporate(0, optcsena10, optcsena100, optcsena1000);
            return corp_opt;
        }

        static double GenrandDouble(Store[] stores)
        {
            double d = 0;
            foreach (Store st in stores)
            {
                foreach (Stoika stoika_1 in st.stoika)
                {
                    foreach (Tovar tovar in stoika_1.tovars)
                    {
                        if (tovar.clas == Clas.Economy)
                        {
                            d = random.Next(10, 1500);
                        }

                        if (tovar.clas == Clas.Standart)
                        {
                            d =  random.Next(1500, 15000);
                        }

                        if (tovar.clas == Clas.Premium)
                        {
                            d = random.Next(15000, 3000000);
                        }
                    }
                }
            }

            return d;
        }
        
        public static string genType(int l, int h)
        {
            string alp_1 = "aeioyu";
            string alp_2 = "bcdfghjklmnpqrstxwzv";
            string result = "";
            for (int i = 0; i < random.Next(l, h); i++)
            {
                if (i % 2 == 0) result += alp_2[random.Next(alp_2.Length)];
                else result += alp_1[random.Next(alp_1.Length)];
            }

            return result;
        }
    }
}
