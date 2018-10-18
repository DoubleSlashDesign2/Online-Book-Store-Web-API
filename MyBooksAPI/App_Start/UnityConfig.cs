using MyBooksAPI.BusinessAccessLayer.IServices;
using MyBooksAPI.BusinessAccessLayer.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MyBooksAPI
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			
			container.RegisterType<ICartService, CartService>();
			container.RegisterType<IHomeService, HomeService>();
			container.RegisterType<IWishListService, WishListService>();
			container.RegisterType<IUserService, UserService>();

			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}