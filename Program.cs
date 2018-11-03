using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo_KızmaBirader_
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] plyr = { "A", "B", "C", "D", "E", "F", "G", "H", "M", "N", "O", "P", "I", "J", "K", "L" };
            string [] konum = new string[56]; // Görseli tamamlayacak dizi oluşturuldu.
            string[] konumdegisen = new string[56];
            string[] plyrdegisen = new string[16];
            int[] sekiltut = new int[11];
            int sekiller1, sekiller2;
            int pozisyon = 0, round = 1, dice, player = 1, enterpawn = 12, wait = 0, wait1 = 0, onemoretime = 0, tekrarsekil = 0, buyukkucuksonsuz = 0, yapayzekakonumtut = 0,kontrol=0,kontrol1=0;
            bool flag = true, flagsoncare = true, flagbitisyerleri = true, tekraroynaodul = true,son=true; 
            Random sekiller = new Random();
            int[] y = { 8, 8, 8, 8, 8, 8, 8, 7, 6, 5, 4, 3, 2, 2, 2, 3, 4, 5, 6, 7, 8, 8, 8, 8, 8, 8, 8, 9, 10, 10, 10, 10, 10, 10, 10, 11, 12, 13, 14, 15, 16, 16, 16, 15, 14, 13, 12, 11, 10, 10, 10, 10, 10, 10, 10, 9 };
            int[] x = { 3, 5, 7, 9, 11, 13, 15, 15, 15, 15, 15, 15, 15, 17, 19, 19, 19, 19, 19, 19, 19, 21, 23, 25, 27, 29, 31, 31, 31, 29, 27, 25, 23, 21, 19, 19, 19, 19, 19, 19, 19, 17, 15, 15, 15, 15, 15, 15, 15, 13, 11, 9, 7, 5, 3, 3 };
            string[] bitisyerleri1 = { "o", "o", "o", "o" };
            string[] bitisyerleri2 = { "o", "o", "o", "o" };
            string[] bitisyerleri3 = { "o", "o", "o", "o" };
            string[] bitisyerleri4 = { "o", "o", "o", "o" };
            for (int i = 0; i < konum.Length; i++)//kalan yerler nokta ile dolduruldu.
            {
                konum[i] = ".";
            }
            for (int i = 0; i < 3; i++)   //istenilen oyun karakterleri olusturuldu.
             {
                 do sekiller1 = sekiller.Next(1, 52); while (sekiller1 == 14 || sekiller1 == 28 || sekiller1 == 42);////oyuncuların başlangıç noktalarının sadece nokta olması sağlandı
                 konum[sekiller1] = ")";
                 sekiltut[i] = sekiller1; //#1sekillerin aynı sayı randomu gelmesi engellendi.(hafızada tutulması)
             }
             for (int i = 3; i < 5; i++)
             {
                 do
                 {
                     tekrarsekil = 0;
                     sekiller2 = sekiller.Next(1, 56);
                     for (int j = 0; j < 11; j++)
                     {
                         if (sekiller2 == sekiltut[j])//sekillerin aynı sayı randomu gelmesi engellendi.
                         {
                             tekrarsekil = 1;
                             break;
                         }

                     }

                 } while (sekiller2 == 14 || sekiller2 == 28 || sekiller2 == 42 || tekrarsekil == 1 || sekiller2 == sekiltut[0]+3 || sekiller2 == sekiltut[1]+3 || sekiller2 == sekiltut[2]+3);
                 konum[sekiller2] = ">";
                 sekiltut[i] = sekiller2;
             }

             for (int i = 8; i < 10; i++)
             {
                 do
                 {
                     tekrarsekil = 0;
                     sekiller2 = sekiller.Next(1, 56);
                     for (int j = 0; j < 11; j++)
                     {
                         if (sekiller2 == sekiltut[j])
                         {
                             tekrarsekil = 1;
                             break;
                         }
                     }

                 } while (sekiller2 == 14 || sekiller2 == 28 || sekiller2 == 42 || tekrarsekil == 1|| sekiller2 == sekiltut[0] + 3 || sekiller2 == sekiltut[1] + 3 || sekiller2 == sekiltut[2] + 3);
                 konum[sekiller2] = "<";
                 sekiltut[i] = sekiller2;
             }
             for (int i = 10; i < 11; i++)
             {
                 do
                 {
                     tekrarsekil = 0;
                     sekiller2 = sekiller.Next(1, 56);
                     for (int j = 0; j < 11; j++)
                     {
                         if (sekiller2 == sekiltut[j])
                         {
                             tekrarsekil = 1;
                             break;
                         }
                     }

                 } while (sekiller2 == 14 || sekiller2 == 28 || sekiller2 == 42 || tekrarsekil == 1|| sekiller2 == sekiltut[0] + 3 || sekiller2 == sekiltut[1] + 3 || sekiller2 == sekiltut[2] + 3);
                 konum[sekiller2] = "X";
             }
             for (int i = 5; i < 8; i++)
             {
                 do
                 {
                     buyukkucuksonsuz = 0;
                     tekrarsekil = 0;
                     sekiller2 = sekiller.Next(1, 56);
                     for (int j = 0; j < 11; j++)
                     {
                         if (sekiller2 == sekiltut[j])
                         {
                             tekrarsekil = 1;
                             break;
                         }
                         else if (sekiller2 >= 4 && konum[sekiller2 - 3] == ")") buyukkucuksonsuz = 1;//"(" ile ")" arasındaki sonsuz döngüye girebilecek durum engellendi.
                     }
                 } while (sekiller2 == 0 || sekiller2 == 1 || sekiller2 == 2 || tekrarsekil == 1 || sekiller2 == 14 || sekiller2 == 15 || sekiller2 == 16 || sekiller2 == 28 || sekiller2 == 29 || sekiller2 == 30 || sekiller2 == 42 || sekiller2 == 43 || sekiller2 == 44 || buyukkucuksonsuz == 1 || sekiller2 == sekiltut[0] + 3 || sekiller2 == sekiltut[1] + 3 || sekiller2 == sekiltut[2] + 3|| konum[sekiller2-3]!=".");//"(" başlangıcın ilk 3ünde olmamalı oyunun sonuna atmaması icin ve diger durumlar.
                 konum[sekiller2] = "(";
                 sekiltut[i] = sekiller2;
             }
            for (int i = 0; i < konum.Length; i++)//başlangıç elementlerinin hafızada tutulması.(yedek)
            {
                konumdegisen[i] = konum[i];
            }
            for (int i = 0; i < plyrdegisen.Length; i++)//başlangıç elementlerinin hafızada tutulması.(yedek)
            {
                plyrdegisen[i] = plyr[i];
            }
            
            ////////////////////////////////////////////////////////////////////////////////ilk adım
            do    //oyun döngüsü-+1round(değiştirilecek)
            {
                dice = sekiller.Next(1, 7);
                while (dice == 6 || onemoretime == 1)//////////////////////////////////dice 6 geldiğinde bir oyun hakkı tanınındı.Ve > kuralı.
                {
                    if (wait == 1)//"<" kuralı sağlandı.
                    {
                        wait = 0;
                        wait1 = 1; //üst üste dice=6 old diğer döngüyüde kırmak için
                        break;
                    }
                    if (onemoretime == 1) onemoretime = 0;//">" kuralı oluşturuldu.

                    Console.SetCursorPosition(0, pozisyon);
                    Console.WriteLine(" Player 1                 Player 2 ");  //Görsel Oluşturuldu.
                    Console.WriteLine(" A B C D     + - - - +     E F G H");
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[0], plyr[1], plyr[4], plyr[5], bitisyerleri2[0]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[2], plyr[3], plyr[6], plyr[7], bitisyerleri2[1]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri2[2]);
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri2[3]);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * ");
                    Console.WriteLine(" |               #               |" + "      |Round: {0}       ", round);
                    Console.WriteLine(" |   {1} {2} {3} {4} # # # # # {5} {6} {7} {8}   |" + "      |Turn: Player{0}  ", player, bitisyerleri1[0], bitisyerleri1[1], bitisyerleri1[2], bitisyerleri1[3], bitisyerleri3[3], bitisyerleri3[2], bitisyerleri3[1], bitisyerleri3[0]);
                    Console.WriteLine(" |               #               |" + "      |Dice: {0}        ", dice);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * * * ");
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri4[3]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri4[2]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[8], plyr[9], plyr[12], plyr[13], bitisyerleri4[1]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[10], plyr[11], plyr[14], plyr[15], bitisyerleri4[0]);
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" M N O P     + - - - +     I J K L");
                    Console.WriteLine(" Player 4                 Player 3");
                    Console.WriteLine("-----------------------------------------");
                    for (int i = 0; i < konum.Length; i++) //setcursor ile tablo tamamlandı.
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write(konum[i]);
                    }

                    Console.SetCursorPosition(41, enterpawn);
                    Console.WriteLine("Enter Pawn: ");
                    Console.SetCursorPosition(53, enterpawn);
                    string choice = Console.ReadLine();
                    if (choice.ToUpper() == "A" || choice.ToUpper() == "B" || choice.ToUpper() == "C" || choice.ToUpper() == "D")
                    {

                        for (int i = 0; i < 56; i++)
                        {
                            if (konum[i] == choice.ToUpper())
                            {
                                if ((i <= 55 && i+dice > 55 && (i + dice - 56) <= 3 && bitisyerleri1[i + dice - 56] == "o") || (i <= 55 && ((i + dice + 3) > 55 && (i + dice - 56 + 3) <= 3 && (i + dice - 56 + 3) >= 0 && (i + dice) < 56 && konum[i + dice] == ")" && bitisyerleri1[i + dice - 56 + 3] == "o")))//bitiş yerlerine girmeleri sağlandı.
                                {
                                    if (i <= 55 && ((i + dice + 3) > 55 && (i + dice - 56 + 3) <= 3&&(i + dice - 56 + 3) >= 0&& (i + dice)<56 && konum[i + dice] == ")" && bitisyerleri1[i + dice - 56 + 3] == "o"))     //bitiş noktasına geldiyse yerleştirdi.
                                        {
                                            bitisyerleri1[i+dice - 56 + 3] = konum[i];
                                            konum[i] = konumdegisen[i];
                                        }
                                        else
                                        {
                                            bitisyerleri1[i+dice - 56] = konum[i];
                                            konum[i] = konumdegisen[i];
                                        }
                                    break;
                                }
                                else if ((i <= 55 && i + dice > 55) || (i <= 55 && konum[i+dice] == ")" && (i + dice + 3) > 55))
                                {
                                    Console.SetCursorPosition(41, enterpawn + 1);
                                    Console.WriteLine("No Legal Move!");
                                    break;
                                }
                                if ((konum[i + dice] == "E" || konum[i + dice] == "F" || konum[i + dice] == "G" || konum[i + dice] == "H" || konum[i + dice] == "M" || konum[i + dice] == "N" || konum[i + dice] == "O" || konum[i + dice] == "P" || konum[i + dice] == "I" || konum[i + dice] == "J" || konum[i + dice] == "K" || konum[i + dice] == "L" || (konum[i + dice] == ")" && (konum[i + dice + 3] == "E" || konum[i + dice + 3] == "F" || konum[i + dice + 3] == "G" || konum[i + dice + 3] == "H" || konum[i + dice + 3] == "M" || konum[i + dice + 3] == "N" || konum[i + dice + 3] == "O" || konum[i + dice + 3] == "P" || konum[i + dice + 3] == "I" || konum[i + dice + 3] == "J" || konum[i + dice + 3] == "K" || konum[i + dice + 3] == "L")) || (konum[i + dice] == "(" && kontrol1 >= 3 && (konum[i + dice - 3] == "E" || konum[i + dice - 3] == "F" || konum[i + dice - 3] == "G" || konum[i + dice - 3] == "H" || konum[i + dice - 3] == "M" || konum[i + dice - 3] == "N" || konum[i + dice - 3] == "O" || konum[i + dice - 3] == "P" || konum[i + dice - 3] == "I" || konum[i + dice - 3] == "J" || konum[i + dice - 3] == "K" || konum[i + dice - 3] == "L"))))
                                {
                                    for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                    {
                                        if (plyrdegisen[j] == konum[i + dice])
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                        else if (plyrdegisen[j] == konum[(i + dice + 3)%56] && konum[i + dice] == ")")
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                        else if (kontrol1 >= 3 &&  plyrdegisen[j] == konum[(i + dice - 3)%56] && konum[i + dice] == "(")
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                    }

                                }
                                if (konum[i + dice] == "A" || konum[i + dice] == "B" || konum[i + dice] == "C" || konum[i + dice] == "D")
                                {
                                    Console.SetCursorPosition(41, enterpawn + 1);
                                    Console.WriteLine("No Legal Move!");
                                    break;
                                }

                                else
                                {
                                    if (konum[i+dice] == ")")     ///////////awards tanımlanması-1
                                        {
                                        if (konum[i + dice + 3] == "A" || konum[i + dice + 3] == "B" || konum[i + dice + 3] == "C" || konum[i + dice + 3] == "D") break;//ödüldeki +3 de kendi taşı varsa ilerlemesi engellendi.
                                        Console.SetCursorPosition(41, enterpawn + 1);
                                        Console.WriteLine("Extra 3 steps!");
                                        konum[i + dice + 3] = konum[i];
                                        konum[i] = konumdegisen[i];
                                        break;
                                    }
                                    else if (konum[i + dice] == "(")
                                    {
                                        if ((konum[i + dice - 3] == "A" || konum[i + dice - 3] == "B" || konum[i + dice - 3] == "C" || konum[i + dice - 3] == "D") && dice != 3) break;//ödüldeki -3 de kendi taşı varsa ilerlemesi engellendi.
                                        Console.SetCursorPosition(41, enterpawn + 1);
                                        Console.WriteLine("Less 3 steps!");
                                        if (konum[i + dice - 3] == konum[i]) break; //aynı yerine gittiyse değişim olmaması için.
                                        konum[i + dice - 3] = konum[i];
                                        konum[i] = konumdegisen[i];
                                        break;
                                    }
                                    else if (konum[i + dice] == "<")
                                    {
                                        Console.SetCursorPosition(41, enterpawn + 1);
                                        Console.WriteLine("Wait for one round without playing!");
                                        wait = 1;
                                        konum[i + dice] = konum[i];
                                        konum[i] = konumdegisen[i];
                                        break;
                                    }
                                    else if (konum[i + dice] == ">")
                                    {
                                        Console.SetCursorPosition(41, enterpawn + 1);
                                        Console.WriteLine("Play one more time!");
                                        onemoretime = 1;
                                        konum[i + dice] = konum[i];
                                        konum[i] = konumdegisen[i];
                                        dice = sekiller.Next(1, 7);
                                        break;
                                    }
                                    else if (konum[i + dice] == "X")
                                    {
                                        Console.SetCursorPosition(41, enterpawn + 1);
                                        Console.WriteLine("Go back to the starting point!");
                                        for (int k = 0; k < 4; k++)
                                        {
                                            if (konum[i] == plyrdegisen[k])
                                            {
                                                plyr[k] = plyrdegisen[k];
                                                break;
                                            }
                                        }
                                        konum[i] = konumdegisen[i];
                                        break;
                                    }
                                    else
                                    {
                                        konum[i + dice] = konum[i];
                                        konum[i] = konumdegisen[i];
                                        break;
                                    }

                                }
                            }
                        }
                        for (int k = 0; k <= 3; k++)
                        {
                            if (plyr[k] == choice.ToUpper())
                            {
                                if (konum[0] == "A" || konum[0] == "B" || konum[0] == "C" || konum[0] == "D")
                                {
                                    Console.SetCursorPosition(41, enterpawn + 1);
                                    Console.WriteLine("No Legal Move!");
                                    break;               //player konum sıfırda piyon varken piyon çıkartamaz.
                                }
                                else if (konum[0]==".")
                                {
                                    konum[0] = plyr[k];
                                    plyr[k] = ".";
                                    break;
                                }
                                else
                                {
                                   for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                    {
                                        if (plyrdegisen[j] == konum[0])
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            konum[0] = plyr[k];
                                            plyr[k] = ".";

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    dice = sekiller.Next(1, 7);
                 }
                ///////////////////////////////////////////////////////////////////////////////
                do
                {
                    if (wait == 1 || wait1 == 1)//"<" kuralı sağlandı.
                    {
                        wait = 0;
                        wait1 = 0;
                        break;
                    }

                    if (onemoretime == 1)//">" kuralı oluşturuldu.
                    {
                        onemoretime = 0;
                    }


                    Console.SetCursorPosition(0, pozisyon);
                    Console.WriteLine(" Player 1                 Player 2 ");  //Görsel Oluşturuldu.
                    Console.WriteLine(" A B C D     + - - - +     E F G H");
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[0], plyr[1], plyr[4], plyr[5], bitisyerleri2[0]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[2], plyr[3], plyr[6], plyr[7], bitisyerleri2[1]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri2[2]);
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri2[3]);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * ");
                    Console.WriteLine(" |               #               |" + "      |Round: {0}       ", round);
                    Console.WriteLine(" |   {1} {2} {3} {4} # # # # # {5} {6} {7} {8}   |" + "      |Turn: Player{0}  ", player, bitisyerleri1[0], bitisyerleri1[1], bitisyerleri1[2], bitisyerleri1[3], bitisyerleri3[3], bitisyerleri3[2], bitisyerleri3[1], bitisyerleri3[0]);
                    Console.WriteLine(" |               #               |" + "      |Dice: {0}        ", dice);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * * * ");
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri4[3]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri4[2]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[8], plyr[9], plyr[12], plyr[13], bitisyerleri4[1]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[10], plyr[11], plyr[14], plyr[15], bitisyerleri4[0]);
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" M N O P     + - - - +     I J K L");
                    Console.WriteLine(" Player 4                 Player 3");
                    Console.WriteLine("-----------------------------------------");



                    for (int i = 0; i < konum.Length; i++) //setcursor ile tablo tamamlandı.
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write(konum[i]);
                    }
                    ///////////////////////////////////////////////////////////
                    Console.SetCursorPosition(41, enterpawn);
                    if (plyr[0] == "A" && plyr[1] == "B" && plyr[2] == "C" && plyr[3] == "D" && dice != 6)//oyun başlaması için dice=6 olmalı.
                    {
                        Console.SetCursorPosition(41, enterpawn + 1);
                        Console.WriteLine("No Legal Move!");
                        Console.SetCursorPosition(41, enterpawn);//dice 6 gelmediğinde direk geçiş olmasın diye.
                        Console.WriteLine("Press Enter To Continue: ");
                        Console.SetCursorPosition(65, enterpawn);
                        Console.ReadLine();

                    }


                    ///////////////////////////////////////////////////////////////////////////dice-diğerleri
                    else if (dice != 6)
                    {
                        Console.WriteLine("Enter Pawn: ");
                        Console.SetCursorPosition(53, enterpawn);
                        string choice = Console.ReadLine();
                        if (choice.ToUpper() == "A" || choice.ToUpper() == "B" || choice.ToUpper() == "C" || choice.ToUpper() == "D")
                        {

                            for (int i = 0; i < 56; i++)
                            {
                                if (konum[i] == choice.ToUpper())
                                {
                                    if (((i <= 55 && i + dice > 55 && (i + dice - 56) <= 3 && bitisyerleri1[i + dice - 56] == "o") || (i <= 55 && ((i + dice + 3) > 55 && (i + dice - 56 + 3) <= 3 && (i + dice - 56 + 3) >= 0 && (i + dice)<56 && konum[i + dice] == ")" && bitisyerleri1[i + dice - 56 + 3] == "o"))))//bitiş yerlerine girmeleri sağlandı.
                                    {
                                        if (i <= 55 && ((i + dice + 3) > 55 && (i + dice - 56 + 3) <= 3 && (i + dice - 56 + 3) >= 0 && (i + dice) < 56 && konum[i + dice] == ")" && bitisyerleri1[i + dice - 56 + 3] == "o"))     //bitiş noktasına geldiyse yerleştirdi.
                                        {
                                            bitisyerleri1[i + dice - 56 + 3] = konum[i];
                                            konum[i] = konumdegisen[i];
                                        }
                                        else
                                        {
                                            bitisyerleri1[i + dice - 56] = konum[i];
                                            konum[i] = konumdegisen[i];
                                        }
                                        break;
                                    }
                                    else if ((i <= 55 && i + dice > 55) || (i <= 55 && konum[i + dice] == ")" && (i + dice + 3) > 55))
                                    {
                                        Console.SetCursorPosition(41, enterpawn + 1);
                                        Console.WriteLine("No Legal Move!");
                                        break;
                                    }
                                    if ((konum[i + dice] == "E" || konum[i + dice] == "F" || konum[i + dice] == "G" || konum[i + dice] == "H" || konum[i + dice] == "M" || konum[i + dice] == "N" || konum[i + dice] == "O" || konum[i + dice] == "P" || konum[i + dice] == "I" || konum[i + dice] == "J" || konum[i + dice] == "K" || konum[i + dice] == "L" || (konum[i + dice] == ")" && (konum[i + dice + 3] == "E" || konum[i + dice + 3] == "F" || konum[i + dice + 3] == "G" || konum[i + dice + 3] == "H" || konum[i + dice + 3] == "M" || konum[i + dice + 3] == "N" || konum[i + dice + 3] == "O" || konum[i + dice + 3] == "P" || konum[i + dice + 3] == "I" || konum[i + dice + 3] == "J" || konum[i + dice + 3] == "K" || konum[i + dice + 3] == "L")) || (konum[i + dice] == "(" && kontrol1 >= 3 && (konum[i + dice - 3] == "E" || konum[i + dice - 3] == "F" || konum[i + dice - 3] == "G" || konum[i + dice - 3] == "H" || konum[i + dice - 3] == "M" || konum[i + dice - 3] == "N" || konum[i + dice - 3] == "O" || konum[i + dice - 3] == "P" || konum[i + dice - 3] == "I" || konum[i + dice - 3] == "J" || konum[i + dice - 3] == "K" || konum[i + dice - 3] == "L"))))
                                    {
                                        for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                        {
                                            if (plyrdegisen[j] == konum[i + dice])
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                            else if (plyrdegisen[j] == konum[(i + dice + 3)%56] && konum[i + dice] == ")")
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                            else if (kontrol1 >= 3 && plyrdegisen[j] == konum[(i + dice - 3)%56] && konum[i + dice] == "(")
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                        }

                                    }
                                    if (konum[i + dice] == "A" || konum[i + dice] == "B" || konum[i + dice] == "C" || konum[i + dice] == "D")
                                    {
                                        Console.SetCursorPosition(41, enterpawn + 1);
                                        Console.WriteLine("No Legal Move!");
                                        break;
                                    }
                                    else
                                    {
                                        if (konum[i + dice] == ")")             ///////////awards tanımlanması-2
                                        {
                                            if (konum[i + dice + 3] == "A" || konum[i + dice + 3] == "B" || konum[i + dice + 3] == "C" || konum[i + dice + 3] == "D") break;//ödüldeki +3 de kendi taşı varsa ilerlemesi engellendi.
                                            Console.SetCursorPosition(41, enterpawn + 1);
                                            Console.WriteLine("Extra 3 steps!");
                                            konum[i + dice + 3] = konum[i];
                                            konum[i] = konumdegisen[i];
                                            break;
                                        }
                                        else if (konum[i + dice] == "(")
                                        {
                                            if ((konum[i + dice - 3] == "A" || konum[i + dice - 3] == "B" || konum[i + dice - 3] == "C" || konum[i + dice - 3] == "D") && dice != 3) break;//ödüldeki -3 de kendi taşı varsa ilerlemesi engellendi.
                                            Console.SetCursorPosition(41, enterpawn + 1);
                                            Console.WriteLine("Less 3 steps!");
                                            if (konum[i + dice - 3] == konum[i]) break; //aynı yerine gittiyse değişim olmaması için.
                                            konum[i + dice - 3] = konum[i];
                                            konum[i] = konumdegisen[i];
                                            break;
                                        }
                                        else if (konum[i + dice] == "<")
                                        {
                                            Console.SetCursorPosition(41, enterpawn + 1);
                                            Console.WriteLine("Wait for one round without playing!");
                                            wait = 1;
                                            konum[i + dice] = konum[i];
                                            konum[i] = konumdegisen[i];
                                            break;
                                        }
                                        else if (konum[i + dice] == ">")
                                        {
                                            Console.SetCursorPosition(41, enterpawn + 1);
                                            Console.WriteLine("Play one more time!");
                                            onemoretime = 1;
                                            konum[i + dice] = konum[i];
                                            konum[i] = konumdegisen[i];
                                            dice = sekiller.Next(1, 6);
                                            break;
                                        }
                                        else if (konum[i + dice] == "X")
                                        {
                                            Console.SetCursorPosition(41, enterpawn + 1);
                                            Console.WriteLine("Go back to the starting point!");
                                            for (int k = 0; k < 4; k++)
                                            {
                                                if (konum[i] == plyrdegisen[k])
                                                {
                                                    plyr[k] = plyrdegisen[k];
                                                    break;
                                                }
                                            }
                                            konum[i] = konumdegisen[i];
                                            break;
                                        }
                                        else
                                        {
                                            konum[i + dice] = konum[i];
                                            konum[i] = konumdegisen[i];
                                            break;
                                        }

                                    }
                                }
                            }
                            for (int k = 0; k <= 3; k++)
                            {
                                if (plyr[k] == choice.ToUpper())
                                {
                                    Console.SetCursorPosition(41, enterpawn + 1);
                                    Console.WriteLine("No Legal Move!");
                                    break;               //zar 6 gelmeden içerideki piyonları yazarsa.
                                }
                            }
                        }
                    }
                } while (onemoretime == 1);
                if ((bitisyerleri1[0] != "o" && bitisyerleri1[1] != "o" && bitisyerleri1[2] != "o" && bitisyerleri1[3] != "o")) break;
                player += 1;
                /////////////////////////////////////////////////////////////////////////// Oyuncu 1 Bitti
                ////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////
                Console.Clear();
                
             //////////////////////////////"yapayzekakonumtut" ile yapay zeka ile normal oyuncu arasındaki fark kapatıldı.(birinde karar verip uygularken diğerinde tüm secenekler bakılıp en son karar verildiği için döngü dışına alındı.)



                dice = sekiller.Next(1, 7);
                while (dice == 6 || onemoretime == 1)//////////////////////////////////dice 6 geldiğinde bir oyun hakkı tanınındı.Ve > kuralı.
                {
                    if (wait == 1)//"<" kuralı sağlandı.
                    {
                        wait = 0;
                        wait1 = 1; //üst üste dice=6 old diğer döngüyüde kırmak için
                        break;
                    }
                    if (onemoretime == 1) onemoretime = 0;//">" kuralı oluşturuldu.

                    Console.SetCursorPosition(0, pozisyon);
                    Console.WriteLine(" Player 1                 Player 2 ");  //Görsel Oluşturuldu.
                    Console.WriteLine(" A B C D     + - - - +     E F G H");
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[0], plyr[1], plyr[4], plyr[5], bitisyerleri2[0]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[2], plyr[3], plyr[6], plyr[7], bitisyerleri2[1]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri2[2]);
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri2[3]);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * ");
                    Console.WriteLine(" |               #               |" + "      |Round: {0}       ", round);
                    Console.WriteLine(" |   {1} {2} {3} {4} # # # # # {5} {6} {7} {8}   |" + "      |Turn: Player{0}  ", player, bitisyerleri1[0], bitisyerleri1[1], bitisyerleri1[2], bitisyerleri1[3], bitisyerleri3[3], bitisyerleri3[2], bitisyerleri3[1], bitisyerleri3[0]);
                    Console.WriteLine(" |               #               |" + "      |Dice: {0}        ", dice);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * * * ");
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri4[3]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri4[2]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[8], plyr[9], plyr[12], plyr[13], bitisyerleri4[1]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[10], plyr[11], plyr[14], plyr[15], bitisyerleri4[0]);
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" M N O P     + - - - +     I J K L");
                    Console.WriteLine(" Player 4                 Player 3");
                    Console.WriteLine("-----------------------------------------");
                    for (int i = 0; i < konum.Length; i++) //setcursor ile tablo tamamlandı.
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write(konum[i]);
                    }

                    Console.SetCursorPosition(41, enterpawn);
                    Console.WriteLine("Press Enter To Continue: ");
                    Console.SetCursorPosition(65, enterpawn);
                    Console.ReadLine();
                    string choice = "-";
                    for (int i = 4; i < 8; i++)//Yapay zekanın ilk seçenek olarak içerden bi taş secmesi sağlandı.
                    {
                        if (konum[14] == "E" || konum[14] == "F" || konum[14] == "G" || konum[14] == "H")
                        {
                            flag = false;
                            break;
                        }
                        else if ((konum[14] == "A" || konum[14] == "B" || konum[14] == "C" || konum[14] == "D" || konum[14] == "M" || konum[14] == "N" || konum[14] == "O" || konum[14] == "P" || konum[14] == "I" || konum[14] == "J" || konum[14] == "K" || konum[14] == "L") && plyr[i] != ".")
                        {
                            choice = plyr[i];
                            break;
                        }
                        else if (plyr[i] != ".")
                        {
                            for (int j = 4; j < 8; j++)//içerden harfi sırasıyla seçmesi saglandı.(diger seçeneklerden dolayı sona kadar gittiği için tekrar kontrol edilmeliydi)
                            {
                                if (plyr[j] != ".")
                                {
                                    flag = true;
                                    choice = plyr[j];
                                    break;
                                }
                            }
                        }
                        else flag = false;//eğer basede piyon yoksa aşagıdaki döngüde bir taş seçildi.
                    }
                    kontrol = 13;/////////////oyuncunun kendi döngüsünde devam etmesi sağlandı.
                    kontrol1 = 13 + dice;// ilerisini kontrol ettirirken denge sağlandı yukarının devamı.
                    for (int i = 14; i < 56 + 14; i++)//Yapay zekanın zar kadar ilerisini kontrol etmesi sağlandı.
                    {
                        kontrol++;
                        kontrol1++;
                        if (i == 56) kontrol = kontrol % 56;
                        if (konum[kontrol] == "E" || konum[kontrol] == "F" || konum[kontrol] == "G" || konum[kontrol] == "H")
                        {
                            if ((kontrol1) > 55) kontrol1 = kontrol1 % 56;
                            if ((kontrol <= 13 && kontrol1 > 13 && (kontrol1 - 14) <= 3 && (kontrol1 - 14) >= 0 && bitisyerleri2[kontrol1 - 14] == "o") || (kontrol <= 13  && ((kontrol1 + 3) > 13 && (kontrol1 - 14 + 3) <= 3 && (kontrol1 - 14 + 3) >= 0 && konum[kontrol1] == ")" && bitisyerleri2[kontrol1 - 14 + 3] == "o")))//bitiş yerlerine girmeleri sağlandı.
                            {
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                                flagbitisyerleri = false;
                                break;
                            }
                            else if ((kontrol <= 13 && kontrol1 > 13) || (kontrol <= 13 && konum[kontrol1] == ")" && (kontrol1 + 3) > 13)) break;
                            if (konum[kontrol1] == ")" || konum[kontrol1] == ">" || konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "M" || konum[kontrol1] == "N" || konum[kontrol1] == "O" || konum[kontrol1] == "P" || konum[kontrol1] == "I" || konum[kontrol1] == "J" || konum[kontrol1] == "K" || konum[kontrol1] == "L" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P" || konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P" || konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L")))
                            {
                                if ((konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "M" || konum[kontrol1] == "N" || konum[kontrol1] == "O" || konum[kontrol1] == "P" || konum[kontrol1] == "I" || konum[kontrol1] == "J" || konum[kontrol1] == "K" || konum[kontrol1] == "L" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P" || konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P" || konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L"))))
                                {
                                    flag = true;
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                    {
                                        if (j == 4) j = 8;
                                        if (plyrdegisen[j] == konum[kontrol1])
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                        else if (plyrdegisen[j] == konum[(kontrol1 + 3)%56] && konum[kontrol1] == ")")
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                        else if (kontrol1 >= 3 && plyrdegisen[j] == konum[(kontrol1 - 3)%56] && konum[kontrol1] == "(")
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                    }
                                    break;

                                }
                                else if ((konum[kontrol1] == ")" || konum[kontrol1] == ">") && flag == false)
                                {
                                    if (konum[kontrol1] == ")" && kontrol != 55 && kontrol != 54 && kontrol != 53 && kontrol != 52 && (konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H")) flag = false;//ödüldeki +3 de kendi taşı varsa ilerlemesi engellendi.
                                    else
                                    {
                                        flag = true;
                                        choice = konum[kontrol];
                                        yapayzekakonumtut = kontrol;
                                    }
                                }
                            }
                            else if ((konum[kontrol1] == ".") && flag == false)
                            {
                                flagsoncare = false;
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                            }
                            else if ((konum[kontrol1] != "E" && konum[kontrol1] != "F" && konum[kontrol1] != "G" && konum[kontrol1] != "H") && flag == false && flagsoncare == true)
                            {
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                            }

                        }
                    }
                    flag = true;
                    flagsoncare = true;
                    if (choice == konum[yapayzekakonumtut])
                    {
                        kontrol1 = yapayzekakonumtut + dice;
                        if (kontrol1 > 55) kontrol1 = kontrol1 % 56;

                        if (flagbitisyerleri == false)         ///////////awards tanımlanması-1
                        {
                            if (kontrol <= 13 && ((kontrol1 + 3) > 13 && (kontrol1 - 14 + 3) <= 3 && konum[kontrol1] == ")" && bitisyerleri2[kontrol1 - 14 + 3] == "o"))     //bitiş noktasına geldiyse yerleştirdi.
                            {
                                bitisyerleri2[kontrol1 - 14 + 3] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                            else
                            {
                                bitisyerleri2[kontrol1 - 14] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                        }
                        else if (konum[kontrol1] == ")")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Extra 3 steps!");
                            konum[kontrol1 + 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "(")
                        {
                            if ((konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H") && dice != 3) break;//ödüldeki -3 de kendi taşı varsa ilerlemesi engellendi.
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Less 3 steps!");
                            if (konum[kontrol1 - 3] == konum[yapayzekakonumtut]) break; //aynı yerine gittiyse değişim olmaması için.
                            konum[kontrol1 - 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "<")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Wait for one round without playing!");
                            wait = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == ">")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Play one more time!");
                            onemoretime = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            dice = sekiller.Next(1, 7);
                            tekraroynaodul = false;
                        }
                        else if (konum[kontrol1] == "X")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Go back to the starting point!");
                            for (int k = 4; k < 8; k++)
                            {
                                if (konum[yapayzekakonumtut] == plyrdegisen[k])
                                {
                                    plyr[k] = plyrdegisen[k];
                                }
                            }
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else
                        {
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }


                    }
                    flagbitisyerleri = true;
                    for (int k = 4; k <= 7; k++)
                    {
                        if (plyr[k] == choice.ToUpper())
                        {
                            if (konum[14] == "E" || konum[14] == "F" || konum[14] == "G" || konum[14] == "H")
                            {
                                Console.SetCursorPosition(41, enterpawn + 1);
                                Console.WriteLine("No Legal Move!");
                                break;               //player konum sıfırda piyon varken piyon çıkartamaz.
                            }
                            else if (konum[14] == ".")
                            {
                                konum[14] = plyr[k];
                                plyr[k] = ".";
                                break;
                            }
                            else
                            {
                                for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                {
                                    if (plyrdegisen[j] == konum[14])
                                    {
                                        plyr[j] = plyrdegisen[j];
                                        konum[14] = plyr[k];
                                        plyr[k] = ".";

                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (tekraroynaodul == true) dice = sekiller.Next(1, 7);
                    tekraroynaodul = true;
                }
                ////////////////////////////////////////////////////////////////ZAR=6 icin yapay zeka tanımlandı.
                ////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////
                do
                {
                    if (wait == 1 || wait1 == 1)//"<" kuralı sağlandı.
                    {
                        wait = 0;
                        wait1 = 0;
                        break;
                    }

                    if (onemoretime == 1)//">" kuralı oluşturuldu.
                    {
                        onemoretime = 0;
                    }


                    Console.SetCursorPosition(0, pozisyon);
                    Console.WriteLine(" Player 1                 Player 2 ");  //Görsel Oluşturuldu.
                    Console.WriteLine(" A B C D     + - - - +     E F G H");
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[0], plyr[1], plyr[4], plyr[5], bitisyerleri2[0]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[2], plyr[3], plyr[6], plyr[7], bitisyerleri2[1]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri2[2]);
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri2[3]);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * ");
                    Console.WriteLine(" |               #               |" + "      |Round: {0}       ", round);
                    Console.WriteLine(" |   {1} {2} {3} {4} # # # # # {5} {6} {7} {8}   |" + "      |Turn: Player{0}  ", player, bitisyerleri1[0], bitisyerleri1[1], bitisyerleri1[2], bitisyerleri1[3], bitisyerleri3[3], bitisyerleri3[2], bitisyerleri3[1], bitisyerleri3[0]);
                    Console.WriteLine(" |               #               |" + "      |Dice: {0}        ", dice);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * * * ");
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri4[3]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri4[2]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[8], plyr[9], plyr[12], plyr[13], bitisyerleri4[1]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[10], plyr[11], plyr[14], plyr[15], bitisyerleri4[0]);
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" M N O P     + - - - +     I J K L");
                    Console.WriteLine(" Player 4                 Player 3");
                    Console.WriteLine("-----------------------------------------");



                    for (int i = 0; i < konum.Length; i++) //setcursor ile tablo tamamlandı.
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write(konum[i]);
                    }
                    ///////////////////////////////////////////////////////////
                    Console.SetCursorPosition(41, enterpawn);
                    if (plyr[4] == "E" && plyr[5] == "F" && plyr[6] == "G" && plyr[7] == "H" && dice != 6)//oyun başlaması için dice=6 olmalı.
                    {
                        Console.SetCursorPosition(41, enterpawn + 1);
                        Console.WriteLine("No Legal Move!");
                    }


                    ///////////////////////////////////////////////////////////////////////////dice-diğerleri
                    else if (dice != 6)
                    {
                        Console.SetCursorPosition(41, enterpawn);
                        Console.WriteLine("Press Enter To Continue: ");
                        Console.SetCursorPosition(65, enterpawn);
                        Console.ReadLine();

                        string choice = "-";
                        kontrol = 13;
                        kontrol1 = 13 + dice;
                        for (int i = 14; i < 56 + 14; i++)
                        {
                            kontrol++;
                            kontrol1++;
                            if (i == 56) kontrol = kontrol % 56;

                            if (konum[kontrol] == "E" || konum[kontrol] == "F" || konum[kontrol] == "G" || konum[kontrol] == "H")
                            {
                                if ((kontrol1) > 55) kontrol1 = kontrol1 % 56;
                                if ((kontrol <= 13 && kontrol1 > 13 && (kontrol1 - 14) <= 3 && (kontrol1 - 14) >= 0 && bitisyerleri2[kontrol1 - 14] == "o") || (kontrol <= 13 && ((kontrol1 + 3) > 13 && (kontrol1 - 14 + 3) <= 3 && (kontrol1 - 14 + 3) >= 0 && konum[kontrol1] == ")" && bitisyerleri2[kontrol1 - 14 + 3] == "o")))//bitiş yerlerine girmeleri sağlandı.
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    flagbitisyerleri = false;
                                    break;
                                }
                                else if ((kontrol <= 13 && kontrol1 > 13) || (kontrol <= 13 && konum[kontrol1] == ")" && (kontrol1 + 3) > 13)) break;
                                if (konum[kontrol1] == ")" || konum[kontrol1] == ">" || konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "M" || konum[kontrol1] == "N" || konum[kontrol1] == "O" || konum[kontrol1] == "P" || konum[kontrol1] == "I" || konum[kontrol1] == "J" || konum[kontrol1] == "K" || konum[kontrol1] == "L" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P" || konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P" || konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L")))
                                {
                                    if (konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "M" || konum[kontrol1] == "N" || konum[kontrol1] == "O" || konum[kontrol1] == "P" || konum[kontrol1] == "I" || konum[kontrol1] == "J" || konum[kontrol1] == "K" || konum[kontrol1] == "L" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P" || konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P" || konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L")))
                                    {
                                        choice = konum[kontrol];
                                        yapayzekakonumtut = kontrol;
                                        son = false;
                                        for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                        {
                                            if (j == 4) j = 8;
                                            if (plyrdegisen[j] == konum[kontrol1])
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                            else if (plyrdegisen[j] == konum[(kontrol1 + 3)%56] && konum[kontrol1] == ")")
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                            else if (kontrol1 >= 3 && plyrdegisen[j] == konum[(kontrol1%56 - 3)%56] && konum[kontrol1] == "(")
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    else if (konum[kontrol1] == ")" || konum[kontrol1] == ">")
                                    {
                                        if (konum[kontrol1] == ")" && kontrol != 55 && kontrol != 54 && kontrol != 53 && kontrol != 52 && (konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H")) flag = true;//ödüldeki +3 de kendi taşı varsa ilerlemesi engellendi.
                                        else
                                        {
                                            choice = konum[kontrol];
                                            yapayzekakonumtut = kontrol;
                                            flag = false;
                                            son = false;
                                        }

                                    }
                                }
                                else if ((konum[14] == "E" || konum[14] == "F" || konum[14] == "G" || konum[14] == "H") && (konum[14 + dice] != "E" && konum[14 + dice] != "F" && konum[14 + dice] != "G" && konum[14 + dice] != "H") && (konum[14 + dice] == ".") && flag == true)//içerden taş çıktıktan sonra ilk iş onu girişten uzaklaştırmak.
                                {
                                    choice = konum[14];
                                    yapayzekakonumtut = 14;
                                    flag = false;
                                    son = false;
                                }

                                else if ((konum[kontrol1] == "<" || konum[kontrol1] == "(") && flag == true && flagsoncare == true)
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }
                                else if (konum[kontrol1] == "X" && flag == true && flagsoncare == true)
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }
                                if (konum[kontrol1] == "." && flag == true)
                                {
                                    flagsoncare = false;
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }

                            }
                        }
                        flag = true;
                        flagsoncare = true;
                        kontrol1 = yapayzekakonumtut + dice;
                        if (kontrol1 > 55) kontrol1 = kontrol1 % 56;
                        if (flagbitisyerleri == false)         ///////////awards tanımlanması-2
                        {
                            if (kontrol <= 13 && ((kontrol1 + 3) > 13 && (kontrol1 - 14 + 3) <= 3 && konum[kontrol1] == ")" && bitisyerleri2[kontrol1 - 14 + 3] == "o"))     //bitiş noktasına geldiyse yerleştirdi.
                            {
                                bitisyerleri2[kontrol1 - 14 + 3] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                            else
                            {
                                bitisyerleri2[kontrol1 - 14] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                        }
                        else if (konum[kontrol1] == ")" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Extra 3 steps!");
                            konum[kontrol1 + 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "(" && son == false)
                        {
                            if ((konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H") && dice != 3) break;//ödüldeki -3 de kendi taşı varsa ilerlemesi engellendi.
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Less 3 steps!");
                            if (konum[kontrol1 - 3] == konum[yapayzekakonumtut]) break; //aynı yerine gittiyse değişim olmaması için.
                            konum[kontrol1 - 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "<" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Wait for one round without playing!");
                            wait = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == ">" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Play one more time!");
                            onemoretime = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            dice = sekiller.Next(1, 6);
                        }
                        else if (konum[kontrol1] == "X" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Go back to the starting point!");
                            for (int k = 4; k < 8; k++)
                            {
                                if (konum[yapayzekakonumtut] == plyrdegisen[k])
                                {
                                    plyr[k] = plyrdegisen[k];
                                    break;
                                }
                            }
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            break;
                        }
                        else if (son == false)
                        {
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        son = true;
                        flagbitisyerleri = true;
                    }
                } while (onemoretime == 1);
                if ((bitisyerleri2[0] != "o" && bitisyerleri2[1] != "o" && bitisyerleri2[2] != "o" && bitisyerleri2[3] != "o")) break;
                player += 1;
                Console.Clear();
                /////////////////////////////////////////////////////////////////////////// Oyuncu 2 bitti.
                ////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////
              Console.Clear();

                //////////////////////////////"yapayzekakonumtut" ile yapay zeka ile normal oyuncu arasındaki fark kapatıldı.(birinde karar verip uygularken diğerinde tüm secenekler bakılıp en son karar verildiği için döngü dışına alındı.)
                dice = sekiller.Next(1, 7);
                while (dice == 6 || onemoretime == 1)//////////////////////////////////dice 6 geldiğinde bir oyun hakkı tanınındı.Ve > kuralı.
                {
                    if (wait == 1)//"<" kuralı sağlandı.
                    {
                        wait = 0;
                        wait1 = 1; //üst üste dice=6 old diğer döngüyüde kırmak için
                        break;
                    }
                    if (onemoretime == 1) onemoretime = 0;//">" kuralı oluşturuldu.

                    Console.SetCursorPosition(0, pozisyon);
                    Console.WriteLine(" Player 1                 Player 2 ");  //Görsel Oluşturuldu.
                    Console.WriteLine(" A B C D     + - - - +     E F G H");
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[0], plyr[1], plyr[4], plyr[5], bitisyerleri2[0]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[2], plyr[3], plyr[6], plyr[7], bitisyerleri2[1]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri2[2]);
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri2[3]);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * ");
                    Console.WriteLine(" |               #               |" + "      |Round: {0}       ", round);
                    Console.WriteLine(" |   {1} {2} {3} {4} # # # # # {5} {6} {7} {8}   |" + "      |Turn: Player{0}  ", player, bitisyerleri1[0], bitisyerleri1[1], bitisyerleri1[2], bitisyerleri1[3], bitisyerleri3[3], bitisyerleri3[2], bitisyerleri3[1], bitisyerleri3[0]);
                    Console.WriteLine(" |               #               |" + "      |Dice: {0}        ", dice);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * * * ");
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri4[3]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri4[2]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[8], plyr[9], plyr[12], plyr[13], bitisyerleri4[1]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[10], plyr[11], plyr[14], plyr[15], bitisyerleri4[0]);
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" M N O P     + - - - +     I J K L");
                    Console.WriteLine(" Player 4                 Player 3");
                    Console.WriteLine("-----------------------------------------");
                    for (int i = 0; i < konum.Length; i++) //setcursor ile tablo tamamlandı.
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write(konum[i]);
                    }

                    Console.SetCursorPosition(41, enterpawn);
                    Console.WriteLine("Press Enter To Continue: ");
                    Console.SetCursorPosition(65, enterpawn);
                    Console.ReadLine();
                    string choice = "-";
                    for (int i = 12; i < 16; i++)//Yapay zekanın ilk seçenek olarak içerden bi taş secmesi sağlandı.
                    {
                        if (konum[28] == "I" || konum[28] == "J" || konum[28] == "K" || konum[28] == "L")
                        {
                            flag = false;
                            break;
                        }
                        else if ((konum[28] == "A" || konum[28] == "B" || konum[28] == "C" || konum[28] == "D" || konum[28] == "M" || konum[28] == "N" || konum[28] == "O" || konum[28] == "P" || konum[28] == "E" || konum[28] == "F" || konum[28] == "G" || konum[28] == "H") && plyr[i] != ".")
                        {
                            choice = plyr[i];
                            break;
                        }
                        else if (plyr[i] != ".")
                        {
                            for (int j = 12; j < 16; j++)//içerden harfi sırasıyla seçmesi saglandı.(diger seçeneklerden dolayı sona kadar gittiği için tekrar kontrol edilmeliydi)
                            {
                                if (plyr[j] != ".")
                                {
                                    flag = true;
                                    choice = plyr[j];
                                    break;
                                }
                            }
                        }
                        else flag = false;//eğer basede piyon yoksa aşagıdaki döngüde bir taş seçildi.
                    }
                    kontrol = 27;/////////////oyuncunun kendi döngüsünde devam etmesi sağlandı.
                    kontrol1 = 27 + dice;// ilerisini kontrol ettirirken denge sağlandı yukarının devamı.
                    for (int i = 28; i < 56 + 28; i++)//Yapay zekanın zar kadar ilerisini kontrol etmesi sağlandı.
                    {
                        kontrol++;
                        kontrol1++;
                        if (i == 56) kontrol = kontrol % 56;
                        if (konum[kontrol] == "I" || konum[kontrol] == "J" || konum[kontrol] == "K" || konum[kontrol] == "L")
                        {
                            if ((kontrol1) > 55) kontrol1 = kontrol1 % 56;
                            if ((kontrol <= 27 && kontrol1 > 27 && (kontrol1 - 28) <= 3 && (kontrol1 - 28) >= 0 && bitisyerleri3[kontrol1 - 28] == "o") || (kontrol <= 27 && ((kontrol1 + 3) > 27 && (kontrol1 - 28 + 3) <= 3 && (kontrol1 - 28 + 3) >= 0 && konum[kontrol1] == ")" && bitisyerleri3[kontrol1 - 28 + 3] == "o")))//bitiş yerlerine girmeleri sağlandı.
                            {
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                                flagbitisyerleri = false;
                                break;
                            }
                            else if ((kontrol <= 27 && kontrol1 > 27) || (kontrol <= 27 && konum[kontrol1] == ")" && (kontrol1 + 3) > 27)) break;
                            if (konum[kontrol1] == ")" || konum[kontrol1] == ">" || konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "M" || konum[kontrol1] == "N" || konum[kontrol1] == "O" || konum[kontrol1] == "P" || konum[kontrol1] == "E" || konum[kontrol1] == "F" || konum[kontrol1] == "G" || konum[kontrol1] == "H" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P" || konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P" || konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H")))
                            {
                                if ((konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "M" || konum[kontrol1] == "N" || konum[kontrol1] == "O" || konum[kontrol1] == "P" || konum[kontrol1] == "E" || konum[kontrol1] == "F" || konum[kontrol1] == "G" || konum[kontrol1] == "H" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P" || konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P" || konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H"))))
                                {
                                    flag = true;
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                    {
                                        if (j == 12) break;
                                        if (plyrdegisen[j] == konum[kontrol1])
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                        else if (plyrdegisen[j] == konum[(kontrol1 + 3)%56] && konum[kontrol1] == ")")
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                        else if (kontrol1 >= 3 && plyrdegisen[j] == konum[(kontrol1 - 3)%56] && konum[kontrol1] == "(")
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                    }
                                    break;

                                }
                                else if ((konum[kontrol1] == ")" || konum[kontrol1] == ">") && flag == false)
                                {
                                    if (konum[kontrol1] == ")" && kontrol != 55 && kontrol != 54 && kontrol != 53 && kontrol != 52 && (konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) flag = false;//ödüldeki +3 de kendi taşı varsa ilerlemesi engellendi.
                                    else
                                    {
                                        flag = true;
                                        choice = konum[kontrol];
                                        yapayzekakonumtut = kontrol;
                                    }
                                }
                            }
                            else if ((konum[kontrol1] == ".") && flag == false)
                            {
                                flagsoncare = false;
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                            }
                            else if ((konum[kontrol1] != "I" && konum[kontrol1] != "J" && konum[kontrol1] != "K" && konum[kontrol1] != "L") && flag == false && flagsoncare == true)
                            {
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                            }

                        }
                    }
                    flag = true;
                    flagsoncare = true;
                    if (choice == konum[yapayzekakonumtut])
                    {
                        kontrol1 = yapayzekakonumtut + dice;
                        if (kontrol1 > 55) kontrol1 = kontrol1 % 56;

                        if (flagbitisyerleri == false)         ///////////awards tanımlanması-1
                        {
                            if (kontrol <= 13 && ((kontrol1 + 3) > 13 && (kontrol1 - 14 + 3) <= 3 && konum[kontrol1] == ")" && bitisyerleri2[kontrol1 - 14 + 3] == "o"))     //bitiş noktasına geldiyse yerleştirdi.
                            {
                                bitisyerleri3[kontrol1 - 28 + 3] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                            else
                            {
                                bitisyerleri3[kontrol1 - 28] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                        }
                        else if (konum[kontrol1] == ")")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Extra 3 steps!");
                            konum[kontrol1 + 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "(")
                        {
                            if ((konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L") && dice != 3) break;//ödüldeki -3 de kendi taşı varsa ilerlemesi engellendi.
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Less 3 steps!");
                            if (konum[kontrol1 - 3] == konum[yapayzekakonumtut]) break; //aynı yerine gittiyse değişim olmaması için.
                            konum[kontrol1 - 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "<")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Wait for one round without playing!");
                            wait = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == ">")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Play one more time!");
                            onemoretime = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            dice = sekiller.Next(1, 7);
                            tekraroynaodul = false;
                        }
                        else if (konum[kontrol1] == "X")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Go back to the starting point!");
                            for (int k = 12; k < 16; k++)
                            {
                                if (konum[yapayzekakonumtut] == plyrdegisen[k])
                                {
                                    plyr[k] = plyrdegisen[k];
                                }
                            }
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else
                        {
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }


                    }
                    flagbitisyerleri = true;
                    for (int k = 12; k <= 15; k++)
                    {
                        if (plyr[k] == choice.ToUpper())
                        {
                            if (konum[28] == "I" || konum[28] == "J" || konum[28] == "K" || konum[28] == "L")
                            {
                                Console.SetCursorPosition(41, enterpawn + 1);
                                Console.WriteLine("No Legal Move!");
                                break;               //player konum sıfırda piyon varken piyon çıkartamaz.
                            }
                            else if (konum[28] == ".")
                            {
                                konum[28] = plyr[k];
                                plyr[k] = ".";
                                break;
                            }
                            else
                            {
                                for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                {
                                    if (plyrdegisen[j] == konum[28])
                                    {
                                        plyr[j] = plyrdegisen[j];
                                        konum[28] = plyr[k];
                                        plyr[k] = ".";

                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (tekraroynaodul == true) dice = sekiller.Next(1, 7);
                    tekraroynaodul = true;
                }
                ////////////////////////////////////////////////////////////////ZAR=6 icin yapay zeka tanımlandı.
                ////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////
                do
                {
                    if (wait == 1 || wait1 == 1)//"<" kuralı sağlandı.
                    {
                        wait = 0;
                        wait1 = 0;
                        break;
                    }

                    if (onemoretime == 1)//">" kuralı oluşturuldu.
                    {
                        onemoretime = 0;
                    }


                    Console.SetCursorPosition(0, pozisyon);
                    Console.WriteLine(" Player 1                 Player 2 ");  //Görsel Oluşturuldu.
                    Console.WriteLine(" A B C D     + - - - +     E F G H");
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[0], plyr[1], plyr[4], plyr[5], bitisyerleri2[0]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[2], plyr[3], plyr[6], plyr[7], bitisyerleri2[1]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri2[2]);
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri2[3]);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * ");
                    Console.WriteLine(" |               #               |" + "      |Round: {0}       ", round);
                    Console.WriteLine(" |   {1} {2} {3} {4} # # # # # {5} {6} {7} {8}   |" + "      |Turn: Player{0}  ", player, bitisyerleri1[0], bitisyerleri1[1], bitisyerleri1[2], bitisyerleri1[3], bitisyerleri3[3], bitisyerleri3[2], bitisyerleri3[1], bitisyerleri3[0]);
                    Console.WriteLine(" |               #               |" + "      |Dice: {0}        ", dice);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * * * ");
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri4[3]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri4[2]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[8], plyr[9], plyr[12], plyr[13], bitisyerleri4[1]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[10], plyr[11], plyr[14], plyr[15], bitisyerleri4[0]);
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" M N O P     + - - - +     I J K L");
                    Console.WriteLine(" Player 4                 Player 3");
                    Console.WriteLine("-----------------------------------------");



                    for (int i = 0; i < konum.Length; i++) //setcursor ile tablo tamamlandı.
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write(konum[i]);
                    }
                    ///////////////////////////////////////////////////////////
                    Console.SetCursorPosition(41, enterpawn);
                    if (plyr[12] == "I" && plyr[13] == "J" && plyr[14] == "K" && plyr[15] == "L" && dice != 6)//oyun başlaması için dice=6 olmalı.
                    {
                        Console.SetCursorPosition(41, enterpawn + 1);
                        Console.WriteLine("No Legal Move!");
                    }


                    ///////////////////////////////////////////////////////////////////////////dice-diğerleri
                    else if (dice != 6)
                    {
                        Console.SetCursorPosition(41, enterpawn);
                        Console.WriteLine("Press Enter To Continue: ");
                        Console.SetCursorPosition(65, enterpawn);
                        Console.ReadLine();

                        string choice = "-";
                        kontrol = 27;
                        kontrol1 = 27 + dice;
                        for (int i = 28; i < 56 + 28; i++)
                        {
                            kontrol++;
                            kontrol1++;
                            if (i == 56) kontrol = kontrol % 56;

                            if (konum[kontrol] == "I" || konum[kontrol] == "J" || konum[kontrol] == "K" || konum[kontrol] == "L")
                            {
                                if ((kontrol1) > 55) kontrol1 = kontrol1 % 56;
                                if ((kontrol <= 27 && kontrol1 > 27 && (kontrol1 - 28) <= 3 && (kontrol1 - 28) >= 0 && bitisyerleri3[kontrol1 - 28] == "o") || (kontrol <= 27 && ((kontrol1 + 3) > 27 && (kontrol1 - 28 + 3) <= 3 && (kontrol1 - 28 + 3) >= 0 && konum[kontrol1] == ")" && bitisyerleri3[kontrol1 - 28 + 3] == "o")))//bitiş yerlerine girmeleri sağlandı.
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    flagbitisyerleri = false;
                                    break;
                                }
                                else if ((kontrol <= 27 && kontrol1 > 27) || (kontrol <= 27 && konum[kontrol1] == ")" && (kontrol1 + 3) > 27)) break;
                                if (konum[kontrol1] == ")" || konum[kontrol1] == ">" || konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "M" || konum[kontrol1] == "N" || konum[kontrol1] == "O" || konum[kontrol1] == "P" || konum[kontrol1] == "E" || konum[kontrol1] == "F" || konum[kontrol1] == "G" || konum[kontrol1] == "H" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P" || konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H")) || (konum[kontrol1] == "(" && kontrol1>=3&& (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P" || konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H")))
                                {
                                    if (konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "M" || konum[kontrol1] == "N" || konum[kontrol1] == "O" || konum[kontrol1] == "P" || konum[kontrol1] == "E" || konum[kontrol1] == "F" || konum[kontrol1] == "G" || konum[kontrol1] == "H" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P" || konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P" || konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H")))
                                    {
                                        choice = konum[kontrol];
                                        yapayzekakonumtut = kontrol;
                                        son = false;
                                        for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                        {
                                            if (j == 12) break;
                                            if (plyrdegisen[j] == konum[kontrol1])
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                            else if (plyrdegisen[j] == konum[(kontrol1 + 3)%56] && konum[kontrol1] == ")")
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                            else if (kontrol1 >= 3 && plyrdegisen[j] == konum[(kontrol1 - 3)%56] && konum[kontrol1] == "(")
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    else if (konum[kontrol1] == ")" || konum[kontrol1] == ">")
                                    {
                                        if (konum[kontrol1] == ")" && kontrol != 55 && kontrol != 54 && kontrol != 53 && kontrol != 52 && (konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) flag = true;//ödüldeki +3 de kendi taşı varsa ilerlemesi engellendi.
                                        else
                                        {
                                            choice = konum[kontrol];
                                            yapayzekakonumtut = kontrol;
                                            flag = false;
                                            son = false;
                                        }

                                    }
                                }
                                else if ((konum[28] == "I" || konum[28] == "J" || konum[28] == "K" || konum[28] == "L") && (konum[28 + dice] != "I" && konum[28 + dice] != "J" && konum[28 + dice] != "K" && konum[28 + dice] != "L") && (konum[28 + dice] == ".") && flag == true)//içerden taş çıktıktan sonra ilk iş onu girişten uzaklaştırmak.
                                {
                                    choice = konum[28];
                                    yapayzekakonumtut = 28;
                                    flag = false;
                                    son = false;
                                }

                                else if ((konum[kontrol1] == "<" || konum[kontrol1] == "(") && flag == true && flagsoncare == true)
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }
                                else if (konum[kontrol1] == "X" && flag == true && flagsoncare == true)
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }
                                if (konum[kontrol1] == "." && flag == true)
                                {
                                    flagsoncare = false;
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }

                            }
                        }
                        flag = true;
                        flagsoncare = true;
                        kontrol1 = yapayzekakonumtut + dice;
                        if (kontrol1 > 55) kontrol1 = kontrol1 % 56;
                        if (flagbitisyerleri == false)         ///////////awards tanımlanması-2
                        {
                            if (kontrol <= 13 && ((kontrol1 + 3) > 13 && (kontrol1 - 14 + 3) <= 3 && konum[kontrol1] == ")" && bitisyerleri2[kontrol1 - 14 + 3] == "o"))     //bitiş noktasına geldiyse yerleştirdi.
                            {
                                bitisyerleri3[kontrol1 - 28 + 3] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                            else
                            {
                                bitisyerleri3[kontrol1 - 28] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                        }
                        else if (konum[kontrol1] == ")" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Extra 3 steps!");
                            konum[kontrol1 + 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "(" && son == false)
                        {
                            if ((konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L") && dice != 3) break;//ödüldeki -3 de kendi taşı varsa ilerlemesi engellendi.
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Less 3 steps!");
                            if (konum[kontrol1 - 3] == konum[yapayzekakonumtut]) break; //aynı yerine gittiyse değişim olmaması için.
                            konum[kontrol1 - 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "<" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Wait for one round without playing!");
                            wait = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == ">" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Play one more time!");
                            onemoretime = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            dice = sekiller.Next(1, 6);
                        }
                        else if (konum[kontrol1] == "X" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Go back to the starting point!");
                            for (int k = 12; k < 16; k++)
                            {
                                if (konum[yapayzekakonumtut] == plyrdegisen[k])
                                {
                                    plyr[k] = plyrdegisen[k];
                                    break;
                                }
                            }
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            break;
                        }
                        else if (son == false)
                        {
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        son = true;
                        flagbitisyerleri = true;
                    }
                } while (onemoretime == 1);
                if ((bitisyerleri3[0] != "o" && bitisyerleri3[1] != "o" && bitisyerleri3[2] != "o" && bitisyerleri3[3] != "o")) break;
                player += 1;
                Console.Clear();
                /////////////////////////////////////////////////////////////////////////// Oyuncu 3 bitti.
                ////////////////////////////////////////////////////////////////////////////
                
                Console.Clear();

                //////////////////////////////"yapayzekakonumtut" ile yapay zeka ile normal oyuncu arasındaki fark kapatıldı.(birinde karar verip uygularken diğerinde tüm secenekler bakılıp en son karar verildiği için döngü dışına alındı.)
                dice = sekiller.Next(1, 7);
                while (dice == 6 || onemoretime == 1)//////////////////////////////////dice 6 geldiğinde bir oyun hakkı tanınındı.Ve > kuralı.
                {
                    if (wait == 1)//"<" kuralı sağlandı.
                    {
                        wait = 0;
                        wait1 = 1; //üst üste dice=6 old diğer döngüyüde kırmak için
                        break;
                    }
                    if (onemoretime == 1) onemoretime = 0;//">" kuralı oluşturuldu.

                    Console.SetCursorPosition(0, pozisyon);
                    Console.WriteLine(" Player 1                 Player 2 ");  //Görsel Oluşturuldu.
                    Console.WriteLine(" A B C D     + - - - +     E F G H");
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[0], plyr[1], plyr[4], plyr[5], bitisyerleri2[0]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[2], plyr[3], plyr[6], plyr[7], bitisyerleri2[1]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri2[2]);
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri2[3]);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * ");
                    Console.WriteLine(" |               #               |" + "      |Round: {0}       ", round);
                    Console.WriteLine(" |   {1} {2} {3} {4} # # # # # {5} {6} {7} {8}   |" + "      |Turn: Player{0}  ", player, bitisyerleri1[0], bitisyerleri1[1], bitisyerleri1[2], bitisyerleri1[3], bitisyerleri3[3], bitisyerleri3[2], bitisyerleri3[1], bitisyerleri3[0]);
                    Console.WriteLine(" |               #               |" + "      |Dice: {0}        ", dice);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * * * ");
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri4[3]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri4[2]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[8], plyr[9], plyr[12], plyr[13], bitisyerleri4[1]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[10], plyr[11], plyr[14], plyr[15], bitisyerleri4[0]);
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" M N O P     + - - - +     I J K L");
                    Console.WriteLine(" Player 4                 Player 3");
                    Console.WriteLine("-----------------------------------------");
                    for (int i = 0; i < konum.Length; i++) //setcursor ile tablo tamamlandı.
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write(konum[i]);
                    }

                    Console.SetCursorPosition(41, enterpawn);
                    Console.WriteLine("Press Enter To Continue: ");
                    Console.SetCursorPosition(65, enterpawn);
                    Console.ReadLine();
                    string choice = "-";
                    for (int i = 8; i < 12; i++)//Yapay zekanın ilk seçenek olarak içerden bi taş secmesi sağlandı.
                    {
                        if (konum[42] == "M" || konum[42] == "N" || konum[42] == "O" || konum[42] == "P")
                        {
                            flag = false;
                            break;
                        }
                        else if ((konum[42] == "A" || konum[42] == "B" || konum[42] == "C" || konum[42] == "D" || konum[42] == "E" || konum[42] == "F" || konum[42] == "G" || konum[42] == "H" || konum[42] == "I" || konum[42] == "J" || konum[42] == "K" || konum[42] == "L") && plyr[i] != ".")
                        {
                            choice = plyr[i];
                            break;
                        }
                        else if (plyr[i] != ".")
                        {
                            for (int j = 8; j < 12; j++)//içerden harfi sırasıyla seçmesi saglandı.(diger seçeneklerden dolayı sona kadar gittiği için tekrar kontrol edilmeliydi)
                            {
                                if (plyr[j] != ".")
                                {
                                    flag = true;
                                    choice = plyr[j];
                                    break;
                                }
                            }
                        }
                        else flag = false;//eğer basede piyon yoksa aşagıdaki döngüde bir taş seçildi.
                    }
                    kontrol = 41;/////////////oyuncunun kendi döngüsünde devam etmesi sağlandı.
                    kontrol1 = 41 + dice;// ilerisini kontrol ettirirken denge sağlandı yukarının devamı.
                    for (int i = 42; i < 56 + 42; i++)//Yapay zekanın zar kadar ilerisini kontrol etmesi sağlandı.
                    {
                        kontrol++;
                        kontrol1++;
                        if (i == 56) kontrol = kontrol % 56;
                        if (konum[kontrol] == "M" || konum[kontrol] == "N" || konum[kontrol] == "O" || konum[kontrol] == "P")
                        {
                            if ((kontrol1) > 55) kontrol1 = kontrol1 % 56;
                            if ((kontrol <= 41 && kontrol1 > 41 && (kontrol1 - 42) <= 3 && (kontrol1 - 42) >= 0 && bitisyerleri4[kontrol1 - 42] == "o") || (kontrol <= 41 && ((kontrol1 + 3) > 41 && (kontrol1 - 42 + 3) <= 3 && (kontrol1 - 42 + 3) >= 0 && konum[kontrol1] == ")" && bitisyerleri4[kontrol1 - 42 + 3] == "o")))//bitiş yerlerine girmeleri sağlandı.
                            {
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                                flagbitisyerleri = false;
                                break;
                            }
                            else if ((kontrol <= 41 && kontrol1 > 41) || (kontrol <= 41 && konum[kontrol1] == ")" && (kontrol1 + 3) > 41)) break;
                            if (konum[kontrol1] == ")" || konum[kontrol1] == ">" || konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "E" || konum[kontrol1] == "F" || konum[kontrol1] == "G" || konum[kontrol1] == "H" || konum[kontrol1] == "I" || konum[kontrol1] == "J" || konum[kontrol1] == "K" || konum[kontrol1] == "L" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H" || konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H" || konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L")))
                            {
                                if ((konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "E" || konum[kontrol1] == "F" || konum[kontrol1] == "G" || konum[kontrol1] == "H" || konum[kontrol1] == "I" || konum[kontrol1] == "J" || konum[kontrol1] == "K" || konum[kontrol1] == "L" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H" || konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H" || konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L"))))
                                {
                                    flag = true;
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                    {
                                        if (j == 8) j = 12;
                                        if (plyrdegisen[j] == konum[kontrol1])
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                        else if (plyrdegisen[j] == konum[(kontrol1 + 3)%56] && konum[kontrol1] == ")")
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                        else if (kontrol1 >= 3 && plyrdegisen[j] == konum[(kontrol1 - 3)%56] && konum[kontrol1] == "(")
                                        {
                                            plyr[j] = plyrdegisen[j];
                                            break;
                                        }
                                    }
                                    break;

                                }
                                else if ((konum[kontrol1] == ")" || konum[kontrol1] == ">") && flag == false)
                                {
                                    if (konum[kontrol1] == ")" && kontrol != 55 && kontrol != 54 && kontrol != 53 && kontrol != 52 && (konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P")) flag = false;//ödüldeki +3 de kendi taşı varsa ilerlemesi engellendi.
                                    else
                                    {
                                        flag = true;
                                        choice = konum[kontrol];
                                        yapayzekakonumtut = kontrol;
                                    }
                                }
                            }
                            else if ((konum[kontrol1] == ".") && flag == false)
                            {
                                flagsoncare = false;
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                            }
                            else if ((konum[kontrol1] != "M" && konum[kontrol1] != "N" && konum[kontrol1] != "O" && konum[kontrol1] != "P") && flag == false && flagsoncare == true)
                            {
                                choice = konum[kontrol];
                                yapayzekakonumtut = kontrol;
                            }

                        }
                    }
                    flag = true;
                    flagsoncare = true;
                    if (choice == konum[yapayzekakonumtut])
                    {
                        kontrol1 = yapayzekakonumtut + dice;
                        if (kontrol1 > 55) kontrol1 = kontrol1 % 56;

                        if (flagbitisyerleri == false)         ///////////awards tanımlanması-1
                        {
                            if (kontrol <= 13 && ((kontrol1 + 3) > 13 && (kontrol1 - 14 + 3) <= 3 && konum[kontrol1] == ")" && bitisyerleri2[kontrol1 - 14 + 3] == "o"))     //bitiş noktasına geldiyse yerleştirdi.
                            {
                                bitisyerleri4[kontrol1 - 42 + 3] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                            else
                            {
                                bitisyerleri4[kontrol1 - 42] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                        }
                        else if (konum[kontrol1] == ")")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Extra 3 steps!");
                            konum[kontrol1 + 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "(")
                        {
                            if ((konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P") && dice != 3) break;//ödüldeki -3 de kendi taşı varsa ilerlemesi engellendi.
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Less 3 steps!");
                            if (konum[kontrol1 - 3] == konum[yapayzekakonumtut]) break; //aynı yerine gittiyse değişim olmaması için.
                            konum[kontrol1 - 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "<")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Wait for one round without playing!");
                            wait = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == ">")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Play one more time!");
                            onemoretime = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            dice = sekiller.Next(1, 7);
                            tekraroynaodul = false;
                        }
                        else if (konum[kontrol1] == "X")
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Go back to the starting point!");
                            for (int k = 8; k < 12; k++)
                            {
                                if (konum[yapayzekakonumtut] == plyrdegisen[k])
                                {
                                    plyr[k] = plyrdegisen[k];
                                }
                            }
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else
                        {
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }


                    }
                    flagbitisyerleri = true;
                    for (int k = 8; k <= 11; k++)
                    {
                        if (plyr[k] == choice.ToUpper())
                        {
                            if (konum[42] == "M" || konum[42] == "N" || konum[42] == "O" || konum[42] == "P")
                            {
                                Console.SetCursorPosition(41, enterpawn + 1);
                                Console.WriteLine("No Legal Move!");
                                break;               //player konum sıfırda piyon varken piyon çıkartamaz.
                            }
                            else if (konum[42] == ".")
                            {
                                konum[42] = plyr[k];
                                plyr[k] = ".";
                                break;
                            }
                            else
                            {
                                for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                {
                                    if (plyrdegisen[j] == konum[42])
                                    {
                                        plyr[j] = plyrdegisen[j];
                                        konum[42] = plyr[k];
                                        plyr[k] = ".";

                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (tekraroynaodul == true) dice = sekiller.Next(1, 7);
                    tekraroynaodul = true;
                }
                ////////////////////////////////////////////////////////////////ZAR=6 icin yapay zeka tanımlandı.
                ////////////////////////////////////////////////////////////////
                ///////////////////////////////////////////////////////////////////////////////
                do
                {
                    if (wait == 1 || wait1 == 1)//"<" kuralı sağlandı.
                    {
                        wait = 0;
                        wait1 = 0;
                        break;
                    }

                    if (onemoretime == 1)//">" kuralı oluşturuldu.
                    {
                        onemoretime = 0;
                    }


                    Console.SetCursorPosition(0, pozisyon);
                    Console.WriteLine(" Player 1                 Player 2 ");  //Görsel Oluşturuldu.
                    Console.WriteLine(" A B C D     + - - - +     E F G H");
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[0], plyr[1], plyr[4], plyr[5], bitisyerleri2[0]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[2], plyr[3], plyr[6], plyr[7], bitisyerleri2[1]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri2[2]);
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri2[3]);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * ");
                    Console.WriteLine(" |               #               |" + "      |Round: {0}       ", round);
                    Console.WriteLine(" |   {1} {2} {3} {4} # # # # # {5} {6} {7} {8}   |" + "      |Turn: Player{0}  ", player, bitisyerleri1[0], bitisyerleri1[1], bitisyerleri1[2], bitisyerleri1[3], bitisyerleri3[3], bitisyerleri3[2], bitisyerleri3[1], bitisyerleri3[0]);
                    Console.WriteLine(" |               #               |" + "      |Dice: {0}        ", dice);
                    Console.WriteLine(" + - - - - - +   #   + - - - - - +" + "      * * * * * ");
                    Console.WriteLine("             |   {0}   |            ", bitisyerleri4[3]);
                    Console.WriteLine(" + - - +     |   {0}   |     + - - +", bitisyerleri4[2]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[8], plyr[9], plyr[12], plyr[13], bitisyerleri4[1]);
                    Console.WriteLine(" | {0} {1} |     |   {4}   |     | {2} {3} |", plyr[10], plyr[11], plyr[14], plyr[15], bitisyerleri4[0]);
                    Console.WriteLine(" + - - +     |       |     + - - +");
                    Console.WriteLine(" M N O P     + - - - +     I J K L");
                    Console.WriteLine(" Player 4                 Player 3");
                    Console.WriteLine("-----------------------------------------");



                    for (int i = 0; i < konum.Length; i++) //setcursor ile tablo tamamlandı.
                    {
                        Console.SetCursorPosition(x[i], y[i]);
                        Console.Write(konum[i]);
                    }
                    ///////////////////////////////////////////////////////////
                    Console.SetCursorPosition(41, enterpawn);
                    if (plyr[8] == "M" && plyr[9] == "N" && plyr[10] == "O" && plyr[11] == "P" && dice != 6)//oyun başlaması için dice=6 olmalı.
                    {
                        Console.SetCursorPosition(41, enterpawn + 1);
                        Console.WriteLine("No Legal Move!");
                    }


                    ///////////////////////////////////////////////////////////////////////////dice-diğerleri
                    else if (dice != 6)
                    {
                        Console.SetCursorPosition(41, enterpawn);
                        Console.WriteLine("Press Enter To Continue: ");
                        Console.SetCursorPosition(65, enterpawn);
                        Console.ReadLine();

                        string choice = "-";
                        kontrol = 41;
                        kontrol1 = 41 + dice;
                        for (int i = 42; i < 56 + 42; i++)
                        {
                            kontrol++;
                            kontrol1++;
                            if (i == 56) kontrol = kontrol % 56;

                            if (konum[kontrol] == "M" || konum[kontrol] == "N" || konum[kontrol] == "O" || konum[kontrol] == "P")
                            {
                                if ((kontrol1) > 55) kontrol1 = kontrol1 % 56;
                                if ((kontrol <= 41 && kontrol1 > 41 && (kontrol1 - 42) <= 3 && (kontrol1 - 42) >= 0 && bitisyerleri4[kontrol1 - 42] == "o") || (kontrol <= 41 && ((kontrol1 + 3) > 41 && (kontrol1 - 42 + 3) <= 3 && (kontrol1 - 42 + 3) >= 0 && konum[kontrol1] == ")" && bitisyerleri4[kontrol1 - 42 + 3] == "o")))//bitiş yerlerine girmeleri sağlandı.
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    flagbitisyerleri = false;
                                    break;
                                }
                                else if ((kontrol <= 41 && kontrol1 > 41) || (kontrol <= 41 && konum[kontrol1] == ")" && (kontrol1 + 3) > 41)) break;
                                if (konum[kontrol1] == ")" || konum[kontrol1] == ">" || konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "E" || konum[kontrol1] == "F" || konum[kontrol1] == "G" || konum[kontrol1] == "H" || konum[kontrol1] == "I" || konum[kontrol1] == "J" || konum[kontrol1] == "K" || konum[kontrol1] == "L" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H" || konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H" || konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L")))
                                {
                                    if (konum[kontrol1] == "A" || konum[kontrol1] == "B" || konum[kontrol1] == "C" || konum[kontrol1] == "D" || konum[kontrol1] == "E" || konum[kontrol1] == "F" || konum[kontrol1] == "G" || konum[kontrol1] == "H" || konum[kontrol1] == "I" || konum[kontrol1] == "J" || konum[kontrol1] == "K" || konum[kontrol1] == "L" || (konum[kontrol1] == ")" && (konum[kontrol1 + 3] == "A" || konum[kontrol1 + 3] == "B" || konum[kontrol1 + 3] == "C" || konum[kontrol1 + 3] == "D" || konum[kontrol1 + 3] == "E" || konum[kontrol1 + 3] == "F" || konum[kontrol1 + 3] == "G" || konum[kontrol1 + 3] == "H" || konum[kontrol1 + 3] == "I" || konum[kontrol1 + 3] == "J" || konum[kontrol1 + 3] == "K" || konum[kontrol1 + 3] == "L")) || (konum[kontrol1] == "(" && kontrol1 >= 3 && (konum[kontrol1 - 3] == "A" || konum[kontrol1 - 3] == "B" || konum[kontrol1 - 3] == "C" || konum[kontrol1 - 3] == "D" || konum[kontrol1 - 3] == "E" || konum[kontrol1 - 3] == "F" || konum[kontrol1 - 3] == "G" || konum[kontrol1 - 3] == "H" || konum[kontrol1 - 3] == "I" || konum[kontrol1 - 3] == "J" || konum[kontrol1 - 3] == "K" || konum[kontrol1 - 3] == "L")))
                                    {
                                        choice = konum[kontrol];
                                        yapayzekakonumtut = kontrol;
                                        son = false;
                                        for (int j = 0; j < 16; j++)//taş yoketme(basesine gönderme) yapıldı.
                                        {
                                            if (j == 8) j = 12;
                                            if (plyrdegisen[j] == konum[kontrol1])
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                            else if (plyrdegisen[j] == konum[(kontrol1 + 3)%56] && konum[kontrol1] == ")")
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                            else if (kontrol1 >= 3 && plyrdegisen[j] == konum[(kontrol1 - 3)%56] && konum[kontrol1] == "(")
                                            {
                                                plyr[j] = plyrdegisen[j];
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                    else if (konum[kontrol1] == ")" || konum[kontrol1] == ">")
                                    {
                                        if (konum[kontrol1] == ")" && kontrol != 55 && kontrol != 54 && kontrol != 53 && kontrol != 52 && (konum[kontrol1 + 3] == "M" || konum[kontrol1 + 3] == "N" || konum[kontrol1 + 3] == "O" || konum[kontrol1 + 3] == "P")) flag = true;//ödüldeki +3 de kendi taşı varsa ilerlemesi engellendi.
                                        else
                                        {
                                            choice = konum[kontrol];
                                            yapayzekakonumtut = kontrol;
                                            flag = false;
                                            son = false;
                                        }

                                    }
                                }
                                else if ((konum[42] == "M" || konum[42] == "N" || konum[42] == "O" || konum[42] == "P") && (konum[42 + dice] != "M" && konum[42 + dice] != "N" && konum[42 + dice] != "O" && konum[42 + dice] != "P") && (konum[42 + dice] == ".") && flag == true)//içerden taş çıktıktan sonra ilk iş onu girişten uzaklaştırmak.
                                {
                                    choice = konum[42];
                                    yapayzekakonumtut = 42;
                                    flag = false;
                                    son = false;
                                }

                                else if ((konum[kontrol1] == "<" || konum[kontrol1] == "(") && flag == true && flagsoncare == true)
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }
                                else if (konum[kontrol1] == "X" && flag == true && flagsoncare == true)
                                {
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }
                                if (konum[kontrol1] == "." && flag == true)
                                {
                                    flagsoncare = false;
                                    choice = konum[kontrol];
                                    yapayzekakonumtut = kontrol;
                                    son = false;
                                }

                            }
                        }
                        flag = true;
                        flagsoncare = true;
                        kontrol1 = yapayzekakonumtut + dice;
                        if (kontrol1 > 55) kontrol1 = kontrol1 % 56;
                        if (flagbitisyerleri == false)         ///////////awards tanımlanması-2
                        {
                            if (kontrol <= 13 && ((kontrol1 + 3) > 13 && (kontrol1 - 14 + 3) <= 3 && konum[kontrol1] == ")" && bitisyerleri2[kontrol1 - 14 + 3] == "o"))     //bitiş noktasına geldiyse yerleştirdi.
                            {
                                bitisyerleri4[kontrol1 - 42 + 3] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                            else
                            {
                                bitisyerleri4[kontrol1 - 42] = konum[yapayzekakonumtut];
                                konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            }
                        }
                        else if (konum[kontrol1] == ")" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Extra 3 steps!");
                            konum[kontrol1 + 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "(" && son == false)
                        {
                            if ((konum[kontrol1 - 3] == "M" || konum[kontrol1 - 3] == "N" || konum[kontrol1 - 3] == "O" || konum[kontrol1 - 3] == "P") && dice != 3) break;//ödüldeki -3 de kendi taşı varsa ilerlemesi engellendi.
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Less 3 steps!");
                            if (konum[kontrol1 - 3] == konum[yapayzekakonumtut]) break; //aynı yerine gittiyse değişim olmaması için.
                            konum[kontrol1 - 3] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == "<" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Wait for one round without playing!");
                            wait = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        else if (konum[kontrol1] == ">" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Play one more time!");
                            onemoretime = 1;
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            dice = sekiller.Next(1, 6);
                        }
                        else if (konum[kontrol1] == "X" && son == false)
                        {
                            Console.SetCursorPosition(41, enterpawn + 1);
                            Console.WriteLine("Go back to the starting point!");
                            for (int k = 8; k < 12; k++)
                            {
                                if (konum[yapayzekakonumtut] == plyrdegisen[k])
                                {
                                    plyr[k] = plyrdegisen[k];
                                    break;
                                }
                            }
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                            break;
                        }
                        else if (son == false)
                        {
                            konum[kontrol1] = konum[yapayzekakonumtut];
                            konum[yapayzekakonumtut] = konumdegisen[yapayzekakonumtut];
                        }
                        son = true;
                        flagbitisyerleri = true;
                    }
                } while (onemoretime == 1);
                if ((bitisyerleri4[0] != "o" && bitisyerleri4[1] != "o" && bitisyerleri4[2] != "o" && bitisyerleri4[3] != "o")) break;
                player += 1;
                Console.Clear();
                /////////////////////////////////////////////////////////////////////////// Oyuncu 4 bitti.
                ////////////////////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////////////////////
                //////////////////////////////////////////////////////////////////////////// 
                round += 1;
                player = 1;
                

            } while (dice>0);
            Console.Clear();
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Winner is the Player " + player);
            Console.ReadLine();
        }
    }
}
 