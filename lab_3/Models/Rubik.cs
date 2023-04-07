namespace lab_3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Rubik")]
    public partial class Rubik
    {
        [Key]
        public int id { get; set; }

        public int? maloai { get; set; }

        [Required]
        [StringLength(100)]
        public string ten { get; set; }

        public string mota { get; set; }

        [StringLength(50)]
        public string hang { get; set; }

        public decimal? gia { get; set; }

        [StringLength(50)]
        public string hinh { get; set; }

        public int? soluongton { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? ngaycapnhat { get; set; }

        public virtual Loai Loai { get; set; }


        public static List<Rubik> GetAll(string searchKey)
        {
            Model1 context = new Model1();
            searchKey = searchKey + "";
            return context.Rubiks.Where(p => p.ten.Contains(searchKey)).ToList();
        }

        public void Insert()
        {
            Model1 context = new Model1();
            try
            {
                context.Rubiks.Add(this);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Rubik FindRubikByid(int id)
        {
            Model1 context = new Model1();
            return context.Rubiks.FirstOrDefault(p => p.id == id);
        }

        public void Update()
        {
            Model1 context = new Model1();
            try
            {
                Rubik find = context.Rubiks.FirstOrDefault(p => p.id == id);
                if (find != null)
                {
                    find.ten = this.ten;
                    find.mota = this.mota;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }


}
