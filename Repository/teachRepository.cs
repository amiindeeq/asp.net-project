using Microsoft.Data.SqlClient;
using shift6.Models;
using System.Data.SqlClient;



namespace shift6.Repository
{
    public class teachRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public teachRepository()  //constructor
        {
            con = new SqlConnection("server=DESKTOP-30GDGQI; database=shiftthree; Integrated Security=True; TrustServerCertificate=True");
        }

        public List<teach> getAll()
        {
            List<teach> data = new List<teach>();
            using (con)
            {
                con.Open();
                string _query = "select * from teacher order by name asc";
                using (SqlCommand cmd = new SqlCommand(_query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data.Add(new teach() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString(), c_id = Convert.ToInt32(dr["c_id"]), e_id = Convert.ToInt32(dr["e_id"]) });
                    }

                }
            }
            return data;

        }


        public teach get_by_id(int id)
        {
            teach data = new teach();
            using (con)
            {
                con.Open();
                string _query = $"select * from teacher where id={id}";
                cmd = new SqlCommand(_query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new teach() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString(), c_id = Convert.ToInt32(dr["c_id"]), e_id = Convert.ToInt32(dr["e_id"]) };
                }
            }
            return data;
        }

        public bool create(string name, int c_id, int e_id )
        {
            using (con)
            {
                con.Open();
                string _query = $"insert into teacher values('{name}',{c_id},{e_id})";
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

        public bool update(int id, string newname, int nc_id, int ne_id)
        {
            using (con)
            {
                con.Open();
                string _query = $"update teacher set name='{newname}' c_id={nc_id} e_id={ne_id}  where id={id}";
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
                string _query = $"delete from teacher where id={id}";
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
