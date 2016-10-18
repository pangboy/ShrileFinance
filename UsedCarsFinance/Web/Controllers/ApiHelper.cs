using System.Collections.Specialized;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
	public class ApiHelper
	{
		public static NameValueCollection GetParameters()
		{
			HttpRequest request = HttpContext.Current.Request;

			NameValueCollection data = new NameValueCollection(
				request.HttpMethod != "GET"
				? request.Form
				: request.QueryString
			);

			for (int i = 0; i < data.Count; i++)
			{
				if (data[i].Trim().Equals(string.Empty))
				{
					data.Remove(data.GetKey(i--));
				}
			}

			return data;
		}
	}
}