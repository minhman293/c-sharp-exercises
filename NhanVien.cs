using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAITAP_KETHUA
{
    abstract class NhanVien
    {
        protected string manv, hoten, gioitinh;
        protected DateTime ngaysinh, ngayvaocoquan;
        protected long socm;
        protected double luongcoban = 1490000;
        abstract public double tinhPhuCap();
        abstract public double tinhThucLinh();
        public String Manv
        {
            set { this.manv = value; }
            get { return this.manv; }
        }
        public String Hoten
        {
            set { this.hoten = value; }
            get { return this.hoten; }
        }
        public String Gioitinh
        {
            set { this.gioitinh = value; }
            get { return this.gioitinh; }
        }
        public DateTime Ngaysinh
        {
            set { this.ngaysinh = value; }
            get { return this.ngaysinh; }
        }
        public DateTime Ngayvaocoquan
        {
            set { this.ngayvaocoquan = value; }
            get { return this.ngayvaocoquan; }
        }
        public long Socm
        {
            set { this.socm = value; }
            get { return this.socm; }
        }
        public NhanVien() { }
        public NhanVien(string mnv, string ten, string gioi, DateTime dob, DateTime ngayvaocq, long scm)
        {
            this.manv = mnv;
            this.hoten = ten;
            this.gioitinh = gioi;
            this.ngaysinh = dob;
            this.ngayvaocoquan = ngayvaocq;
            this.socm = scm;
        }
        public int tinhThamNien()
        {
            DateTime hientai = DateTime.Today;
            return (int)((hientai - this.ngayvaocoquan).TotalDays / 365.242199);
        }
        public virtual void Nhap()
        {
            Console.WriteLine("Nhap ma nhan vien: ");
            this.manv = Console.ReadLine();
            Console.WriteLine("Nhap ten nhan vien: ");
            this.hoten = Console.ReadLine();
            Console.WriteLine("Nhap gioi tinh nhan vien: ");
            this.gioitinh = Console.ReadLine();
            Console.WriteLine("Nhap ngay sinh nhan vien: ");
            this.ngaysinh = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhap ngay vao co quan: ");
            this.ngayvaocoquan = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Nhap so chung minh nhan vien: ");
            this.socm = long.Parse(Console.ReadLine());
        }
        public virtual void Xuat()
        {
            Console.WriteLine("ma nhan vien: " + this.manv);
            Console.WriteLine("ten nhan vien: " + this.hoten);
            Console.WriteLine("gioi tinh nhan vien: " + this.gioitinh);
            Console.WriteLine("ngay sinh nhan vien: " + this.ngaysinh.ToString("dd/MM/yyyy"));
            Console.WriteLine("ngay vao co quan: " + this.ngayvaocoquan.ToString("dd/MM/yyyy"));
            Console.WriteLine("so chung minh nhan vien: " + this.socm);
            Console.WriteLine("tham nien nhan vien: " + this.tinhThamNien());
        }

    }
}
