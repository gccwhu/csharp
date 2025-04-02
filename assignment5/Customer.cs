using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    public class Customer
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Customer(int id,string name, string address, string phone, string email)
        {
            Id = id; 
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }
        //重写ToString方法
        public override string ToString()
        {
            return "ID:"+Id+"\tName: " + Name + "\tAddress: " + Address + "\tPhone: " + Phone + "\tEmail: " + Email;
        }
        //重写Equals方法    
        public override bool Equals(object obj)
        {
            //只需要比较ID   
            return obj is Customer customer && 
                   customer != null &&
                   Id == customer.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
