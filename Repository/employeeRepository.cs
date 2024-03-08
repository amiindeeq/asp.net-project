using Microsoft.Data.SqlClient;
using shift6.Models;
using System.Data.SqlClient;




namespace shift6.Repository
{
    public class employeeRepository
    {

        SqlConnection con;
        SqlCommand cmd;
        public employeeRepository()  //constructor
        {
            con = new SqlConnection("server=DESKTOP-30GDGQI; database=shiftthree; Integrated Security=True; TrustServerCertificate=True");
        }

        public List<employee> getAll()
        {
            List<employee> data = new List<employee>();
            using (con)
            {
                con.Open();
                string _query = "select * from employee order by name asc";
                using (SqlCommand cmd = new SqlCommand(_query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data.Add(new employee() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString(), phone = dr["phone"].ToString() });
                    }

                }
            }
            return data;

        }


        public employee get_by_id(int id)
        {
            employee data = new employee();
            using (con)
            {
                con.Open();
                string _query = $"select * from employee where id={id}";
                cmd = new SqlCommand(_query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new employee() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString(), phone = dr["phone"].ToString() };
                }
            }
            return data;
        }

        public bool create(string name, string phone)
        {
            using (con)
            {
                con.Open();
                string _query = $"insert into employee values('{name}','{phone}')";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool update(int id, string newname, string newphone)
        {
            using (con)
            {
                con.Open();
                string _query = $"update employee set name='{newname}' phone='{newphone}' where id={id}";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool delete(int id)
        {
            using (con)
            {
                con.Open();
                string _query = $"delete from employee where id={id}";
                cmd = new SqlCommand(_query, con);

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
}
