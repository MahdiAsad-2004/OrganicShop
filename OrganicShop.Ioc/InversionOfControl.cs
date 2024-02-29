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
using OrganicShop.Domain;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using OrganicShop.BLL.Mappers;
using StructureMap.AutoMocking;


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

            var repositoryClasstypes = new List<Type>();
            var serviceClasstypes = new List<Type>();
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (var assembly in assemblies)
            {
                //Console.WriteLine(assembly.GetName());
                foreach (var type in assembly.GetTypes().Where(a => a.IsClass && (a.Name.EndsWith("Service") || a.Name.EndsWith("Repository"))))
                {
                    if (type.Name.EndsWith("Service"))
                    {
                        serviceClasstypes.Add(type);
                    }
                    else
                    {
                        repositoryClasstypes.Add(type);
                    }
                    Console.WriteLine($"\t{type.Name}");
                }
            }
            Console.WriteLine("-----------------------------------------------------------------------------");


            container.RegisterMany(repositoryClasstypes, Reuse.Scoped, serviceTypeCondition: t => t.IsRepositoryType());
            container.RegisterMany(serviceClasstypes, Reuse.Scoped, serviceTypeCondition: t => t.IsServiceType());


            container.RegisterInstance<IMapper>(new Mapper(MappingConfiguration.GetConfiguration()));


            //foreach (var item in container.GetServiceRegistrations())
            //{
            //    Console.WriteLine(item.ImplementationType.Name + "  ____  " + item.ServiceType.Name);
            //}

           

            return container;
        }


    }


    public static class TypeExtension
    {
        public static bool IsRepositoryType(this Type type)
        {
            return type.IsAssignableTo(typeof(IRepository)) && type.IsInterface && type != typeof(IRepository);
        }

        public static bool IsServiceType(this Type type)
        {
            return /*type.IsAssignableTo(typeof(IService<>)) &&*/ type.IsInterface && !type.Name.StartsWith("IService");
        }
    }

}