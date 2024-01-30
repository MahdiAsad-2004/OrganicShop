using System.Reflection;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using DryIoc.Messages;
using DryIoc.ImTools;
using DryIoc.FastExpressionCompiler;
using DryIoc.FastExpressionCompiler.LightExpression;
using System.ComponentModel;
using StructureMap.TypeRules;
using OrganicShop.Domain.IServices;
using OrganicShop.BLL;
using OrganicShop.Domain.IRepositories;
using OrganicShop.DAL.Repositories;
using OrganicShop.BLL.Services;


namespace OrganicShop.Ioc
{
    public class InversionOfControl
    {
        //public Assembly[] Assemblies { get; set; } = AppDomain.CurrentDomain.GetAssemblies();
        //public Assembly[] MyAssemblies { get; set; } = new Assembly[0];

        public static DryIoc.Container GetContainer()
        {
            var container = new DryIoc.Container();

            IRepository repository;
            UserRepository userRepository;
            UserService userService;

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith(nameof(OrganicShop))).ToArray();

            var types = new List<Type>();
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (var assembly in assemblies)
            {
                Console.WriteLine(assembly.GetName());
                foreach (var type in assembly.GetTypes().Where(a => a.IsClass && (a.Name.EndsWith("Service") || a.Name.EndsWith("Repository"))))
                {
                    if (type is not null)
                    {
                        Console.WriteLine($"\t{type.Name}");
                        types.Add(type);
                    }
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------");

            container.RegisterMany(types, serviceTypeCondition: t => t.IsInterface);

            return container;
        }

       
    }


}