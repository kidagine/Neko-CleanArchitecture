namespace NekoPetShop.Infrastructure.SQLData
{
	public interface IDBInitializer
	{
		void Seed(NekoPetShopContext context);
	}
}
