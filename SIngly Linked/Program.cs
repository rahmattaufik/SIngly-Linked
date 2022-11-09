using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIngly_Linked
{
    class Node
    {
        public int noMhs;
        public string nama;
        public Node next;
    }
    
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNode()/*Method untuk menambahkan sebuah node kedalam list*/
        {
            int nim;
            string nm;
            Console.WriteLine("\nMasukkan Nomor Mahasiswa : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan Nama Mahasiswa : ");
            nm = Console.ReadLine();
            Node nodebaru = new Node();
            nodebaru.noMhs = nim;
            nodebaru.nama = nm;

            if (START == null || nim <= START.noMhs)/*Node Ditambahkan sebuah node*/
            {
                if((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nNomor Mahasiswa tidak diijinkan\n");
                    return;
                }
                nodebaru.next = START;
                START = nodebaru;
                return;
            }
            /*Menemukan lokasi Node baru didalam list*/
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nim >= current.noMhs))
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nNomor mahasiswa sama tidak diijinkan");
                    return;
                }
                previous = current;
                current = current.next;
            }
            /*Node Baru akan ditempatkan diantara previous dan current*/

            nodebaru.next = current;
            previous.next = nodebaru;

        }
        /*Method untuk menghapus node tertentu didalam list*/
        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            /*Check apakah node yang dimaksud ada didalam list atau tidak*/
            if (Search(nim, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        /*Method untuk mengecheck apakah node yang dimaksud ada didalam list atau tidak*/
        public bool Search(int nim, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (nim != current.noMhs))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void traverse()
        {
            if (ListEmpty())
                Console.WriteLine("\nList Kosong : \n");
            else
            {
                Console.WriteLine("\nData didalam list adalah : \n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + "" + currentNode.nama + "\n");
                Console.WriteLine();

            }
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        class Program
        {
            static void Main(String[] args)
            {
                List obj = new List();
                while (true)
                {
                    try
                    {
                        Console.WriteLine("\nMenu");
                        Console.WriteLine("1. Menambah data kedalam list");
                        Console.WriteLine("2. Menghapus data dari dalam list");
                        Console.WriteLine("3. Melihat semua data dalam list");
                        Console.WriteLine("4. Mencari sebuah data dalam list");
                        Console.WriteLine("5. Exit");
                        Console.Write("\n Masukkan pilihan anda (1-5) : ");
                        char ch = Convert.ToChar(Console.ReadLine());
                        switch (ch)
                        {
                            case '1':
                                {
                                    obj.addNode();
                                }
                                break;
                            case '2':
                                {
                                    if (obj.ListEmpty())
                                    {
                                        Console.WriteLine("\nList Kosong");
                                        break;
                                    }
                                    Console.Write("\nMasukkan Nomor mahasiswa yang akan dihapus : ");
                                    int nim = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                    if (obj.delNode(nim) == false)
                                        Console.WriteLine("\nData tidak ditemukan. ");
                                    else
                                        Console.WriteLine("Data dengan nomor mahasiswa " + nim + " dihapus ");

                                }
                                break;
                            case '3':
                                {
                                    obj.traverse();
                                }
                                break;
                            case '4':
                                {
                                    if (obj.ListEmpty() == true)
                                    {
                                        Console.WriteLine("\nList Kosong !");
                                        break;
                                    }
                                    Node previous, current;
                                    previous = current = null;
                                    Console.Write("\nMasukkan nomor mahasiswa yang akan dicari");
                                    int num = Convert.ToInt32(Console.ReadLine());
                                    if (obj.Search(num, ref previous, ref current) == false)
                                        Console.WriteLine("\nData tidak ditemukan.");
                                    else
                                    {
                                        Console.WriteLine("\nData ketemu");
                                        Console.WriteLine("\nNomor Mahasiswa : " + current.noMhs);
                                        Console.WriteLine("\nNama: " + current.nama);

                                    }

                                }
                                break;
                            case '5':
                                return;
                            default:
                                {
                                    Console.WriteLine("\nPilihan tidak valid");
                                    break;
                                }
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("\nCheck Nilai yang anda masukkan");
                    }
                }
            }
        }
    }

    
    
}
