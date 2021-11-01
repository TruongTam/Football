using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FootballManaga.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FootballManaga.Models
{
    public class Club
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Tên Câu Lạc Bộ")]
        public string Name { get; set; }
        public string Pitch { get; set; }
        public string Province { get; set; }
        public string AddProvince { get; set; }

        public Club (string id, string name, string Pitch, string Province, string AddP)
        {
            this.Id = id;
            this.Name = name;
            this.Pitch = Pitch;
            this.Province = Province;
            this.AddProvince = AddProvince;
        }
        public void addClub(string Name, string Id, string Province, string Pitch, string Addr)
        {
            QLBongDaContext qLBongDaContext = new QLBongDaContext();
            SqlCommand sql = new SqlCommand("AddClub");
            sql.CommandType = CommandType.StoredProcedure;
            //@ma varchar(10),@name Nvarchar(50),@masan varchar(10),@Tensan nvarchar(50),@addr nvarchar(100), @matinh varchar(10),@tentinh varchar(50)
            sql.Parameters.Add(new SqlParameter("@ma",Id));
            sql.Parameters.Add(new SqlParameter("@name",Name));
            sql.Parameters.Add(new SqlParameter("@masan",getID(Pitch)));
            sql.Parameters.Add(new SqlParameter("@Tensan", Pitch));
            sql.Parameters.Add(new SqlParameter("@addr", Addr));
            sql.Parameters.Add(new SqlParameter("@matinh", getID(Province)));
            sql.Parameters.Add(new SqlParameter("@tentinh", Province));
            sql.ExecuteNonQuery();
        }
        string getID(string Pro)
        {
            string pro =""+Pro[0];
            for(int i=0; i < Pro.Length; i++)
            {
                if(Pro[i]==' ')
                {
                    pro += Pro[i + 1];
                }
                break;
            }
            return pro;//testcase "_Bình Định" => fail
        }



    }
}
    
