using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAITAP_KETHUA
{
    class Program
    {
        static DanhSachNhanVien ds;
        static void Menu()
        {
            Console.WriteLine("nhap 1 - 6 de chon chuc nang: ");
            Console.WriteLine("1. nhap nhan vien");
            Console.WriteLine("2. xuat nhan vien");
            Console.WriteLine("3. tim nhan vien");
            Console.WriteLine("4. xoa nhan vien");
            Console.WriteLine("5. thong ke nhan vien");
            Console.WriteLine("6. tinh quy luong");
            int chon = int.Parse(Console.ReadLine());
            switch (chon)
            {
                case 1:
                    {
                        ds.Nhap();
                        break;
                    }
                case 2:
                    {
                        ds.Xuat();
                        break;
                    }
                case 3:
                    {
                        ds.Tim().Xuat();
                        break;
                    }
                case 4:
                    {
                        ds.Xoa();
                        break;
                    }
                case 5:
                    {
                        ds.ThongKe();
                        break;
                    }
                case 6:
                    {
                        ds.TongLuong();
                        break;
                    }
                default:
                    Menu();
                    break;
            }
        }
        static void Main(string[] args)
        {
            ds = new DanhSachNhanVien();
            char c = 'y';
            while (c == 'y')
            {
                Menu();
                Console.WriteLine("nhap (y) de tro lai menu");
                c = char.Parse(Console.ReadLine().ToLower());
            }
        }
    }
}
