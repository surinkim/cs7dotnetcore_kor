using System.Threading.Tasks;
using Ch15_MobileApp.Models;
using Xamarin.Forms;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Ch15_MobileApp
{
	public partial class CustomersList : ContentPage
	{
		public CustomersList()
		{
			InitializeComponent();

			//Customer.SampleData();

			var client = new HttpClient();

			client.BaseAddress = new Uri(
			  "http://localhost:5000/api/customers");

			client.DefaultRequestHeaders.Accept.Add(
			   new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = client.GetAsync("").Result;

			response.EnsureSuccessStatusCode();

			string content =
			  response.Content.ReadAsStringAsync().Result;

			var customersFromService = JsonConvert.DeserializeObject
			  <IEnumerable<Customer>>(content);

			foreach (Customer c in customersFromService
					 .OrderBy(customer => customer.CompanyName))
			{
				Customer.Customers.Add(c);
			}

			BindingContext = Customer.Customers;
		}

		async void Customer_Tapped(object sender,
		  Xamarin.Forms.ItemTappedEventArgs e)
		{
			Customer c = e.Item as Customer;
			if (c == null) return;
			// 선택한 customer의 상세 뷰를 탐색해서 보여준다.
			await Navigation.PushAsync(new CustomerDetail(c));
		}

		async void Customers_Refreshing(
		  object sender, System.EventArgs e)
		{
			ListView listView = sender as ListView;
			listView.IsRefreshing = true;
			// 실제 리프레쉬 처럼 보이도록 약간의 시간을 소비한다.
			await Task.Delay(1500);
			listView.IsRefreshing = false;
		}

		void Customer_Deleted(object sender, System.EventArgs e)
		{
			MenuItem menuItem = sender as MenuItem;
			Customer c = menuItem.BindingContext as Customer;
			Customer.Customers.Remove(c);
		}

		async void Customer_Phoned(object sender, System.EventArgs e)
		{
			MenuItem menuItem = sender as MenuItem;
			Customer c = menuItem.BindingContext as Customer;
			if (await this.DisplayAlert("Dial a Number",
						  "Would you like to call " + c.Phone + "?",
						  "Yes", "No"))
			{
				var dialer = DependencyService.Get<IDialer>();
				if (dialer != null)
					dialer.Dial(c.Phone);
			}
		}

		async void Add_Activated(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new CustomerDetail());
		}
	}
}
