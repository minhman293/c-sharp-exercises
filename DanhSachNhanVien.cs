using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAITAP_KETHUA
{
    class DanhSachNhanVien
    {
        Dictionary<String, NhanVien> listStaff;
        public DanhSachNhanVien()
        {
            this.listStaff = new Dictionary<string, NhanVien>();
        }
        public void Nhap()
        {
            char c = 'y';
            while (c == 'y')
            {
                NhanVien nv = null;
                char loai = ' ';
                Console.WriteLine("nhap (B) cho bien che, (H) cho hop dong");
                loai = char.Parse(Console.ReadLine().ToUpper());
                if (loai == 'B')
                {
                    nv = new NhanVienBienChe();
                    nv.Nhap();
                }
                else if (loai == 'H')
                {
                    nv = new NhanVienHopDong();
                    nv.Nhap();
                }
                if (nv != null)
                    this.listStaff.Add(nv.Manv, nv);
                Console.WriteLine("nhan (y) de tiep tuc");
                c = char.Parse(Console.ReadLine().ToLower());
            }
        }
        public void Xuat()
        {
            Console.WriteLine("ma nhan vien | ho ten | ngay sinh | gioi tinh | so cm | phu cap | thuc linh");
            foreach (NhanVien nv in listStaff.Values)
                Console.WriteLine("{0, 2} {1, 10} {2, 20}", nv.Manv, nv.Hoten, nv.Ngaysinh.ToString("dd/MM/yyyy"));
        }
        public NhanVien Tim()
        {
            Console.WriteLine("nhap ma nhan vien can tim: ");
            String manv = Console.ReadLine();
            return this.listStaff[manv];
        }
        public void Xoa()
        {
            Console.WriteLine("nhap ma nhan vien can xoa: ");
            String manv = Console.ReadLine();
            this.listStaff.Remove(manv);
        }
        public void ThongKe()
        {
            int tongbienche = 0;
            int tonghopdong = 0;

            foreach (NhanVien nv in this.listStaff.Values)
                if (nv is NhanVienBienChe)
                    tongbienche++;
                else if (nv is NhanVienHopDong)
                    tonghopdong++;

            Console.WriteLine("tong so nhan vien bien che: " + tongbienche);
            Console.WriteLine("tong so nhan vien hop dong: " + tonghopdong);
        }
        public void TongLuong()
        {
            double tongluong = 0;
            foreach (NhanVien nv in this.listStaff.Values)
                tongluong += nv.tinhThucLinh();
            Console.WriteLine("tong quy luong: " + tongluong);
        }
    }
}
