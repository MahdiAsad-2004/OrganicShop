﻿// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Services;
using OrganicShop.DAL;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain;
using OrganicShop.Domain.Dtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using StructureMap.TypeRules;
using static System.Net.Mime.MediaTypeNames;
using System.Linq.Expressions;
using System.ComponentModel;
using OrganicShop.Domain.Dtos.Base;
using AutoMapper;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.CategoryDtos;
using System.Text;
using Microsoft.Extensions.Primitives;
using OrganicShop.Domain.Enums.EnumValues;
using System.Collections.ObjectModel;
using OrganicShop.Domain.Entities.Relations;


Console.WriteLine("Hello, World!\n");























//float x = ((float)378839 / 1024 / 1000);

//Console.WriteLine($"{x}");
//Console.WriteLine($"{x*1000}");
//Console.WriteLine((x*1000).ToString("0.00"));
//Console.WriteLine(x.ToString("0.000"));

//Console.WriteLine("-------------------------------");


//Console.WriteLine(x.ToSize());
//Console.WriteLine(1.26f.ToSize());















//var product = new Product()
//{
//    DiscountProducts = new List<DiscountProducts>
//    {
//        new DiscountProducts{ DiscountId = 1 , Discount = new Discount() { Id = 1, Count = 11 }},
//        new DiscountProducts{ DiscountId = 2 , Discount = new Discount() { Id = 2, Count = 12 }},
//        new DiscountProducts{ DiscountId = 3 , Discount = new Discount() { Id = 3, Count = 13 }}
//    }
//};
//var discountProduct = product.DiscountProducts.First(a => a.DiscountId == 2);
//discountProduct.Discount.Count = 1465;
//discountProduct = product.DiscountProducts.First(a => a.DiscountId == 3);
//discountProduct.Discount.Id = 333;

//foreach (var item in product.DiscountProducts)
//{
//    Console.WriteLine($"{item.Id} --- {item.Discount.Id} --- {item.Discount.Count}");
//}












//Console.WriteLine($"{null == default(int?)}");




//var x = new List<Property>()
//{
//    new Property{Id = 4 , BaseId = 1, Value = "ad"},
//    new Property{Id = 5 , BaseId = 2, Value = "asd"},
//};


//Dictionary<int, (string Id, string Value)> Props = new Dictionary<int, (string Id, string Value)>();

//Props = x.ToDictionary(a => a.BaseId.Value, a => (a.Id.ToString(), a.Value));

//(string AA, string BB) m = ("a", "b");

//m = new Tuple<string, string>("sdf", "sdfsfd").ToValueTuple();

//Console.WriteLine(m.AA);

//Console.WriteLine(Props.Count);





//Console.WriteLine(DateTime.Now.Date);
//Console.WriteLine(DateTime.Today);
//Console.WriteLine(DateTime.Now.ToShortDateString());





//foreach (var item in Enum.GetValues(typeof(CategoryType)))
//{
//    //Console.WriteLine(item.GetType().Name);
//    Console.WriteLine(item.ToString());
//    Console.WriteLine(item.GetType());
//}

//EnumExtension.GetArray();













//var x = new User
//{
//    Id = 4,
//    Name = "fsdfs",
//    BaseEntity = new BaseEntity(true),
//};

//Console.WriteLine(Log(x));





static string Log<T>(T obj)
{
    StringBuilder stringBuilder = new StringBuilder();
    Console.WriteLine($"{typeof(T).Name}:");
    foreach (var prop in typeof(T).GetProperties())
    {
        //if (prop.GetType() == typeof(string) || prop.GetType() == typeof(int) || prop.GetType() == typeof(long) || prop.GetType() == typeof(DateTime) || prop.GetType() == typeof(bool))
        //{
        //    stringBuilder.AppendLine($"\t{prop.Name}: {prop.GetValue(obj)}");
        //}
        //if (prop.GetValue(obj) != null)
        //{
        //    if(prop.GetValue(obj).GetType().IsEnum == false && prop.GetValue(obj).GetType().IsValueType == false && prop.GetValue(obj).GetType().IsString() == false)
        //    {
        //        stringBuilder.AppendLine($"\t{prop.Name}: {prop.GetValue(obj)}");
        //    }
        //    else
        //    {
        //        Log(prop.GetValue(obj));
        //    }
        //}
        //else
        //{
        //    Log(prop.GetValue(obj));
        //}

        stringBuilder.AppendLine($"\t{prop.Name}: {prop.GetValue(obj)}");
        //Console.WriteLine(prop.GetValue(obj) != null ? prop.GetValue(obj).GetType() : "null");
        //Console.WriteLine(prop.GetType().GetType());
    }
    return stringBuilder.ToString();
}
























//MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
//{
//    c.CreateMap<x, y>().ReverseMap();
//});
//var _Mapper = mapperConfiguration.CreateMapper();
//var xObj = new x(45);
//var yObj = _Mapper.Map<y>(xObj);

//yObj.ToString();

//public class x
//{
//    public int Id { get; set; }
//    public string Name { get; set; }

//    public x(object obj)
//    {

//    }
//}

//public class y
//{
//    public int Id { get; set; }
//    public string Name { get; set; }

//    public y(bool? flag = null)
//    {

//    }
//}












//var category = new Category();
//var create = new CreateCategoryDto()
//{
//    Title = "Titleee             ",
//    Type = CategoryType.Product,
//    ImageFile = null,
//    ParentId = null,
//    IconClass = null,
//    IconColor = null,
//};
//MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
//{
//    c.ValueTransformers.Add<string?>(a => a == null ? null : a.Trim());
//    c.CreateMap<CreateCategoryDto, Category>();
//});

//var _Mapper = mapperConfiguration.CreateMapper();


//category = _Mapper.Map<Category>(create);

//Console.WriteLine($"{category.Title} --- {category.Type} --- {category.IconClass} --- {category.IconColor}");



















//List<Tag> tags = new List<Tag>
//{
//    new Tag(){Id = 5 , Title = "A"},
//    new Tag(){Id = 2 , Title = "C"},
//    new Tag(){Id = 3 , Title = "Z"},
//    new Tag(){Id = 1 , Title = "E"},
//    new Tag(){Id = 4 , Title = "B"},
//};


//Func<Tag, object> sss = a => a.Title;  

//foreach (var item in tags.OrderBy(sss))
//{
//    Console.WriteLine($"{item.Id} ----- {item.Title}");
//}







//var permission = new Permission { Id = 1, EnTitle = "Permission 1", Subs = new List<Permission>() };

//for (byte j = 1; j <= 3; j++)
//{
//    var x = new Permission() { Id = (byte)(1 * 10 + j), EnTitle = $"Permission {1}-{j}", Subs = new List<Permission>() };

//    for (byte z = 1; z <= 3; z++)
//    {
//        x.Subs.Add(new Permission() { Id = (byte)((1 * 100) + (j * 10) + z), EnTitle = $"Permission{1}-{j}-{z}", Subs = new List<Permission>() });
//    }

//    permission.Subs.Add(x);
//}

//var allPermissions = new List<Permission>();
//permission.GetAllChilds(allPermissions);

//foreach (var item in allPermissions)
//{
//    Console.WriteLine($"Id: {item.Id} \t Title: {item.EnTitle}");
//}








//MapperConfiguration mapperConfiguration = new MapperConfiguration(a =>
//{

//});



//var type = typeof(IProductService);
//Console.WriteLine(type.IsAssignableTo(typeof(IService<IAggregateRoot>)));






//object address = new Address();
//Console.WriteLine(address.GetType().Name);
//address = typeof(Address);
//Console.WriteLine(address.GetType().Name);


//var x = new Expression<Func>>

//var a = typeof(Product);

//List<Product> products = new();

//products.OrderBy(a => a.Barcode);

//Func<Product, object> func = (a) => a.Barcode;








//var typess = new List<Type>();

//foreach (var assembly in assemblies)
//{
//    Console.WriteLine(assembly.GetName());
//	foreach (var item in assembly.GetLoadedModules())
//	{
//        //Console.WriteLine(item.Name);
//    }
//}

//Console.WriteLine(typess.Count);


//var types = new List<Type>();
//var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith(nameof(OrganicShop)));
//foreach (var assembly in allAssemblies)
//{
//    Console.WriteLine(assembly.FullName);
//    //Console.WriteLine(assembly.GetTypes().Count());
//    //foreach (var type in assembly.GetTypes()/*.Where(a => a.IsClass && (a.Name.EndsWith("Service") || a.Name.EndsWith("Repository")))*/)
//    //{

//    //        Console.WriteLine(type.FullName);
//    //    if (type is not null)
//    //    {
//    //        //types.Add(type);
//    //    }
//    //}
//}

//Console.WriteLine("-----------------------------------------------------------------------");


//var services = ourProjectAssemblies
//   .Where(t => t.FullName!.EndsWith("Service"));
//var repositories = ourProjectAssemblies
//  .Where(t => t.FullName!.EndsWith("Repository"));





//OrganicShopDbContext dbContext = new OrganicShopDbContext();
//IUserRepository _userrepository = new UserRepository() { _context = dbContext };
//IUserService _userService = new UserService(_userrepository);


//Console.WriteLine($"User Count: {_userrepository.GetQueryable().Count()}");

//var user = new User
//{
//    Email = "testEmail.com",
//    Name = "Mhadi",
//    Password = "123456",
//    Role = Role.Customer,
//    PhoneNumber = "09359939353",
//    Addresses = new[]
//    {
//        new Address
//        {
//            Phone = "0212566",
//            PostCode = "31225",
//            Text = "texttt",
//            Title = "titleee",
//            BaseEntity = new BaseEntity(true),
//            SoftDelete = new SoftDelete(true),
//        }
//    },
//};

//await _userrepository.Add(user, 1);





//var baseentity = new BaseEntity();
//var softDelete = new SoftDelete();
//Console.WriteLine($"CreateDate: {baseentity.CreateDate}\tLastModified: {baseentity.LastModified}\tIsActive:{baseentity.IsActive}");
//Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
//Console.WriteLine($"IsDelete: {softDelete.IsDelete}\t\tDeleteDate: {softDelete.DalateDate}");



//var users = await _userrepository.GetQueryable().Include(a => a.Addresses).ToListAsync();
//Console.WriteLine(users.Count);
//Console.WriteLine(users.First().Addresses.Count);






//UserUpdateDto update = new UserUpdateDto
//{
//    Id = 1,
//    Name = "Mahdi Asadi",
//    Email = "mas1379as@gmail.com",
//    ProfileImage = null,
//};

//Console.WriteLine(await _userService.Update(update));

//var filter = await _userService.GetAll(new UserFilterDto()
//{
//    DeleteFilter = DeleteFilter.NotDeleted,
//    ActiveFilter = IsActiveFilter.All,
//    PageItemsCount = 12,
//    PageNumber = 1,
//});

//foreach (var item in filter.Users)
//{
//    Console.WriteLine($"Id: {item.Id}\tName: {item.Name}\tPhoneNumber: {item.PhoneNumber}\tEmail: {item.Email}");
//}
//Console.WriteLine($"\nPage Number:{filter.PageNumber}\tPage Items Count:{filter.PageItemsCount}\tAll Items Count:{filter.Pager.AllItemsCount}\tLastPage:{filter.Pager.LastPageNumber}");
//Console.WriteLine(filter.Pager.PageStatus());







//ITagRepository _tagRepository  = new TagRepository() { _context = dbContext};

////await _tagRepository.Add(new Tag { Title = "Tag 1"},1);
////await _tagRepository.Add(new Tag { Title = "Tag 2"},2);

//var updateTag = new UpdateTag
//{
//    Title = "Tag 1",
//};

//static Tag ToUpdate(Tag tag , UpdateTag update)
//{
//    tag.Title = update.Title;
//    return tag;
//}

//var tag = await _tagRepository.GetAsNoTracking(1);
////await _tagRepository.Update(ToUpdate(tag,updateTag),1);

//dbContext.Update(tag);
//dbContext.SaveChanges();




//IUserRepository _userrepository  = new UserRepository() { _context = dbContext};

//var user = await _userrepository.GetAsNoTracking(1);
//Console.WriteLine($"Username: {user.Username}\tPassword: {user.Password}\tPhoneNumber: {user.PhoneNumber}");


//var user = await _userrepository.GetAsTracking(1);
//user.Username = "MahdiAsadi83";
//user.Password = "123456";
//user.PhoneNumber = "09369753041";
//user.BaseEntity.LastModified = DateTime.Now;
//user.UserInfo.FirstName = "Mahdi";
//user.UserInfo.LastName = "Asadi";
//user.UserInfo.Email = "Mas1379as@gmail.com";
//user.UserInfo.Gender = Gender.Man;
//await _userrepository.Update(user,1);

//await dbContext.SaveChangesAsync();


//dbContext.Users.Update(user);
//await dbContext.SaveChangesAsync();








//public class UpdateTag
//{
//    public string Title { get; set; }
//}








//var product = new Product
//{
//    Title = "TestProduct",
//    Description = "Description",
//    Price = 1_000_000,
//    ShortDescription = "Short Description",
//    SoldCount = 0,
//    Stock = 5,
//    BaseEntity = new BaseEntity
//    {
//        CreaeteDate = DateTime.Now,
//        LastModified = DateTime.Now,
//        IsActive = true
//    },
//    SoftDelete = new SoftDelete
//    {
//        DalateDate = null,
//        IsDelete = false
//    },
//};
//dbContext.Products.Add(product);
//dbContext.SaveChanges();































//List<User> add_users = new List<User>
//{
//        new User()
//        {
//            Username = "MahdiAsadi83",Password = "123456",PhoneNumber = "09369753041",
//            BaseEntity = new BaseEntity
//            {
//                CreaeteDate = DateTime.Now,LastModified = DateTime.Now,IsActive = true
//            },
//            SoftDelete = new SoftDelete
//            {
//                IsDelete = false,DalateDate = null,
//            },
//            UserInfo = new UserInfo
//            {
//                Email = "Mas1379as@gmail.com",FirstName = "Mahdi",LastName = "Asadi",Gender = Gender.Man
//            }
//        },
//        new User()
//        {
//            Username = "Amir6",Password = "1234",PhoneNumber = "09331234566",
//            BaseEntity = new BaseEntity
//            {
//                CreaeteDate = DateTime.Now,LastModified = DateTime.Now,
//            },
//            SoftDelete = new SoftDelete
//            {
//                IsDelete = false,DalateDate = null,
//            },
//        }
//};

//dbContext.Users.AddRange(add_users);
//dbContext.SaveChanges();


