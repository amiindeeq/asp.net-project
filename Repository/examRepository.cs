using Microsoft.Data.SqlClient;
using shift6.Models;
using System.Data.SqlClient;



namespace shift6.Repository
{
    public class examRepository
    {
        SqlConnection con;
        SqlCommand cmd;
        public examRepository()  //constructor
        {
            con = new SqlConnection("server=DESKTOP-30GDGQI; database=shiftthree; Integrated Security=True; TrustServerCertificate=True");
        }

        public List<exam> getAll()
        {
            List<exam> data = new List<exam>();
            using (con)
            {
                con.Open();
                string _query = "select * from exam order by name asc";
                using (SqlCommand cmd = new SqlCommand(_query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        data.Add(new exam() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString(), assignment = dr["assignment"].ToString(), quiz = dr["quiz"].ToString(), midterm = dr["midtrem"].ToString(), final = dr["final"].ToString() });
                    }

                }
            }
            return data;

        }


        public exam get_by_id(int id)
        {
            exam data = new exam();
            using (con)
            {
                con.Open();
                string _query = $"select * from exam where id={id}";
                cmd = new SqlCommand(_query, con);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data = new exam() { id = Convert.ToInt32(dr["id"]), name = dr["name"].ToString(), assignment = dr["assignment"].ToString(), quiz = dr["quiz"].ToString(), midterm = dr["midtrem"].ToString(), final = dr["final"].ToString() };
                }
            }
            return data;
        }

        public bool create(string name, string assignment, string quiz, string midterm, string final)
        {
            using (con)
            {
                con.Open();
                string _query = $"insert into exam values('{name}','{assignment}','{quiz}','{midterm}','{final}')";
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

        public bool update(int id, string newname, string nassignment, string nquiz, string nmidterm, string nfinal)
        {
            using (con)
            {
                con.Open();
                string _query = $"update exam set name='{newname}' assignment='{nassignment}' midtrem='{nmidterm}' final='{nfinal} where id={id}";
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
                string _query = $"delete from exam where id={id}";
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
