using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Diagnostics;

class ChuongTrinhGame
{
    static Dictionary<string, List<int>> playerScores = new Dictionary<string, List<int>>();
    static string nguoichoi = string.Empty;

    public static void Main()
    {

        Console.OutputEncoding = Encoding.UTF8; //Gõ 
        Console.InputEncoding = Encoding.Unicode;
        NameGame();
        string message = "Nhấn phím bất kỳ để tiếp tục...";
        Print((Console.BufferWidth - message.Length) / 2,
              Console.BufferHeight / 2 + 7,
              message,
              ConsoleColor.DarkRed);
        string nguoichoi = "";
        Console.ReadKey(true);
        while (true)
        {
            Console.Clear();
            ShowMenu();
        }
    }
    public static void NameGame()
    {
        string[] Name = new string[]
        {
                @" _______   ___                            ___                                      _______                          ",
                @"/ $$$$$ \  $$|                            $$|                             ___     /$$$$$$$\                            ",
                @"$$     $ | $$|                            $$|                            /$$$\    $$      $|                            ",
                @"$$     $$| $$|                            $$|                            \$$$/    $$ $$$$ $|                            ",
                @"$$ $$$ $$| $$|___    ______     ______    $$|        ______     ______    __      $$ _____/    ______      ______   ",
                @"$$ _____/  $$ $$$\  / $$$$$|   /$$$ $$\   $$|       / $$$$ \   / $$$$$|   $$|     $$ | $$$\   / $$$$$|   /$$$$$$/    ",
                @"$$ |       $$ __$| $$$   $$|_   $$__ $|   $$|       $$    $$| $$$   $$|_  $$|     $$ |   $$\ $$$   $$|_  $$  --    ",
                @"$$ |       $$ | $|  $$    $$|$| $$|  $|   $$|____   $$    $$| $$    $$$|$ $$|     $$ |    $$\ $$    $$$| $$$|____   ",
                @"$$ |       $$ | $|   $$$$$$$ /  $$/  $/   $$$$$$$$$  $$$$$ /   $$$$$$$ /  $$|     $$ |      $\ $$$$$$$/   \$$$$$$\   ",
        };

        Print((Console.BufferWidth - Name[0].Length) / 2,
              Math.Max(0, Console.BufferHeight / 2 - 6),
              Name,
              ConsoleColor.DarkGreen);
    }

    public static void Print(int x, int y, string text, ConsoleColor color)
    {
        if (x < 0 || y < 0 || y >= Console.BufferHeight) return;

        Console.SetCursorPosition(Math.Max(0, x), y);
        Console.ForegroundColor = color;
        Console.Write(text.Length > Console.BufferWidth ? text.Substring(0, Console.BufferWidth) : text);
        Console.ResetColor();
    }

    public static void Print(int x, int y, string[] text, ConsoleColor color)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (y + i >= Console.BufferHeight) break;

            string line = text[i].Length > Console.BufferWidth
                          ? text[i].Substring(0, Console.BufferWidth) : text[i];

            Console.SetCursorPosition(Math.Max(0, x), y + i);
            Console.ForegroundColor = color;
            Console.Write(line);
        }
        Console.ResetColor();
    }

    static void ShowMenu()
    {
        Console.Clear();

        // Tính toán vị trí y bắt đầu và x để căn giữa
        int yStart = (Console.BufferHeight - 3) / 2; // 3 dòng menu
        int xStart = (Console.BufferWidth - 73) / 2; // Độ dài chuỗi dài nhất là 73 ký tự

        // Định nghĩa các màu cho từng chức năng
        ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red };

        // In dòng trên cùng của menu
        Console.SetCursorPosition(xStart, yStart);

        Console.ForegroundColor = colors[0];
        Console.Write("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ForegroundColor = colors[1];
        Console.Write("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ForegroundColor = colors[2];
        Console.Write("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ForegroundColor = colors[3];
        Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓   ");
        Console.ResetColor();

        // In dòng giữa với từng màu cho chức năng
        Console.SetCursorPosition(xStart, yStart + 1);
        Console.ForegroundColor = colors[0];
        Console.Write("┃ 1. Bắt đầu chơi ┃   ");
        Console.ForegroundColor = colors[1];
        Console.Write("┃  2. Hướng dẫn   ┃   ");
        Console.ForegroundColor = colors[2];
        Console.Write("┃ 3. Cài đặt nhạc ┃   ");
        Console.ForegroundColor = colors[3];
        Console.WriteLine("┃    4. Thoát     ┃");
        Console.ResetColor();

        // In dòng dưới cùng của menu

        Console.SetCursorPosition(xStart, yStart + 2);
        Console.ForegroundColor = colors[0];
        Console.Write("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ForegroundColor = colors[1];
        Console.Write("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ForegroundColor = colors[2];
        Console.Write("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ForegroundColor = colors[3];
        Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛   ");
        Console.ResetColor();
        // In lời nhắc nhập lựa chọn bên dưới menu
        string prompt = "Mời bấm phím để lựa chọn: ";
        int promptX = (Console.BufferWidth - prompt.Length) / 2;
        Console.SetCursorPosition(promptX, yStart + 4);
        Console.Write(prompt);

        // Xử lý nhập lựa chọn
        int choice;
        try
        {
            choice = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Vui lòng nhập một số nguyên hợp lệ.");
            Console.WriteLine("Ấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
            return;
        }

        switch (choice)
        {
            case 1:
                NhapThongTin();
                break;

            case 2:
                HuongDanChoi();
                break;

            case 3:
                Console.WriteLine("Cài đặt nhạc chưa được triển khai.");
                Console.WriteLine("Ấn phím bất kỳ để quay lại menu chính...");
                Console.ReadKey();
                break;

            case 4:
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Phím bấm không hợp lệ");
                Console.WriteLine("Ấn phím bất kỳ để quay lại menu chính...");
                Console.ReadKey();
                break;
        }
    }

    static void NhapThongTin()
    {
        Console.Clear();

        while (true)
        {
            try
            {
                Console.Write("Nhập tên người chơi: ");
                nguoichoi = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nguoichoi))
                {
                    throw new Exception("Tên người chơi không thể rỗng");
                }
                if (nguoichoi.All(char.IsDigit))
                {
                    throw new Exception("Tên người chơi không thể là số");
                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine($"Chào mừng {nguoichoi} đến với game!");
        Console.WriteLine("Nhấn phím bất kỳ để bắt đầu game hoặc ESC để quay lại menu chính.");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Escape)
            {
                return;
            }
            else
            {
                XuLyChoi();
                break;
            }
        }
    }
    static void HuongDanChoi()
    {
        Console.Clear();
        Console.WriteLine("\t\tHƯỚNG DẪN");
        Console.WriteLine("Khi bạn bấm vào chơi thì máy sẽ ngẫu nhiên đưa ra 1 câu hỏi trong bộ câu hỏi có sẵn. ");
        Console.WriteLine("Sau đó bạn sẽ suy nghĩ và chọn đáp án đúng.");
        Console.WriteLine("Do đây là mô hình phân loại 7 nên sẽ quy ước: \r\n1. Chất lỏng\r\n2. Thực phẩm thừa\r\n3. Kim loại\r\n4. Nhựa tái chế\r\n5. Giấy\r\n6. Hộp sữa \r\n7. Rác thải còn lại. \r\n");
        Console.WriteLine("Trò chơi gồm 3 round, mỗi round sẽ có 5 câu hỏi theo mức độ khó tăng dần: trả lời đúng 1 câu sẽ được 1 điểm");
        Console.WriteLine("NHỚ TẮT BỘ GÕ TIẾNG VIỆT TRƯỚC KHI CHƠI");
        Console.WriteLine("\nNhấn ESC để thoát hướng dẫn");

        while (Console.ReadKey().Key != ConsoleKey.Escape) ;

    }
    static void XuLyChoi()
    {
        Console.Clear();
        Random rand = new Random(); // Đối tượng Random để trộn câu hỏi
        string[,] cauhoi = new string[30, 5] {
 {"Những rác thải nào thuộc nhóm “Rác thải còn lại”?", "A. Túi nilon, hộp xốp, dụng cụ ăn uống gỗ", "B. Hộp sữa giấy, bìa carton", "C. Hộp nhựa, ống hút nhựa", "D. Hộp thực phẩm, đinh, ốc" },
{"Giấy báo, giấy vở, bìa carton thuộc loại rác nào?", "A. Rác thải còn lại", "B. Hộp sữa", "C. Giấy","D. Kim loại" },
{"“Mô hình 3” của UEH Go Green Station gồm:", "A. Chất lỏng, thực phẩm thừa, rác thải còn lại", "B. Thực phẩm thừa, rác tái chế, rác thải còn lại", "C. Chất lỏng, giấy, hộp sữa", "D. Thực phẩm thừa, rác tái chế, chất lỏng" },
{"Trung bình một người Việt Nam thải ra bao nhiêu tấn CO2 mỗi năm?","A. 2 tấn", "B. 3 tấn", "C. 2,5 tấn", "D. 2,3 tấn" },
{"Trước khi xả thải, UEHer, cá nhân ra vào UEH, cần phải làm gì?", "A. Bóc tách rác", "B. Thực hiện cùng lúc phương án A và C", "C. Phân loại rác", "D. Bỏ tất cả vào 1 túi" },
{ "UEHer hay khách vào UEH cần phải tuân thủ nguyên tắc phân loại rác theo mô hình:", "A. Mô hình 4 và 5", "B. Mô hình 5 và 6", "C. Mô hình 3 và 7", "D. Mô hình 5 và 7" },
{ "Hộp thực phẩm làm bằng kim loại sẽ thuộc nhóm nào trong Mô hình 7?", "A. Kim loại", "B. Chất lỏng", "C. Rác thải còn lại", "D. Rác tái chế" },
{ "Loại rác nào dưới đây không thuộc nhóm “Rác tái chế”?", "A. Giấy báo", "B. Chai nhựa", "C. Khẩu trang y tế", "D. Hộp sữa giấy" },
{ "Một chai lọ bị vỡ nên được xử lý như thế nào?", "A. Phân loại vào nhóm Thực phẩm thừa", "B. Bọc kỹ bằng giấy và bỏ vào nhóm Rác thải còn lại", "C. Bỏ trực tiếp vào nhóm Rác thải còn lại", "D. Đập nhỏ thành mảnh vụn trước khi bỏ vào thùng tái chế" },
{ "Những rác thải nào sau đây cần được phân vào nhóm Rác tái chế: ", "A. Chai, lọ nhựa, rác sân vườn", "B. Giấy báo, ly giấy, đinh, ốc", "C. Dụng cụ ăn uống gỗ, ống hút nhựa", "D. Khăn giấy, khẩu trang" },
{ "Khi bạn uống không hết ly matcha latte, phần thừa còn lại trong ly cần được phân loại vào nhóm: ", "A. Rác tái chế", "B. Rác thải còn lại", "C. Giấy", "D. Chất lỏng" },
{ "Loại giấy nào dưới đây được phân loại vào nhóm \"Giấy\" trong mô hình 7? ", "A. Khăn giấy đã qua sử dụng", "B. Giấy báo, sách cũ", "C. Vỏ hộp sữa giấy", "D. Giấy vệ sinh đã qua sử dụng" },
{ "Chất nào sau đây là chất thải khó phân hủy? ", "A. Giấy", "B. Vật chất nhôm", "C. Giấy nhôm", "D. Bông" },
{ "Chất thải động vật có thể chuyển đổi thành… ", "A. Khí tự nhiên", "B. Khí dầu lỏng (LPG)", "C. Khí sinh học", "D. Không có cái nào ở trên" },
{ "Chất thải rắn bao gồm tất cả các loại sau đây, ngoại trừ: ", "A. Báo và chai nước ngọt", "B. Thức ăn thừa và mảnh sân", "C. Ozone và carbon dioxide", "D. Thư rác và hộp sữa" },
{ "Loại chất thải nào phân hủy hoàn toàn khi chôn vào đất? ", "A. Chất thải thực vật", "B. Chất thải nhựa", "C. Chất thải kim loại", "D. Chất thải động vật" },
{ "Rác thải nào sau đây là rác hữu cơ? ", "A. Xương cá", "B. Túi nilon", "C. Pin đã qua sử dụng", "D. Hộp sữa giấy" },
{ "Rác thải nguy hại bao gồm loại nào sau đây? ", "A. Hộp sữa đã qua sử dụng", "B. Pin, ắc quy cũ", "C. Lốp xe cũ", "D. Giấy carton" },
{ "Kim loại phế liệu thuộc loại rác nào? ", "A. Rác thải nguy hại", "B. Rác tái chế", "C. Rác hữu cơ", "D. Rác sinh hoạt không tái chế" },
{ "Bạn đang uống cà phê mang đi và thấy một thùng rác phân loại. Ly cà phê của bạn thuộc loại nào? ", "A. Rác hữu cơ", "B. Rác tái chế (sau khi rửa sạch)", "C. Rác thải nguy hại", "D. Rác thải thông thường" },
{ "Một chiếc áo cũ nhưng vẫn sử dụng được nên làm gì? ","A. Vứt vào thùng rác tái chế", "B. Tặng hoặc tái sử dụng", "C. Vứt chung với rác sinh hoạt", "D. Bỏ vào thùng rác hữu cơ" },
{ "Bạn nên xử lý dầu ăn thừa như thế nào? ", "A. Đổ vào bồn rửa chén", "B. Đổ trực tiếp ra môi trường", "C. Lưu trữ trong chai và giao cho đơn vị xử lý dầu thải", "D. Bỏ vào thùng rác tái chế" },
{ "Pin cũ nếu không được xử lý đúng cách sẽ gây nguy hại gì?", "A. Gây cháy nổ", "B. Ô nhiễm đất và nước", "C. Phát tán kim loại nặng vào môi trường", "D. Tất cả các ý trên" },
{ "Bình xịt (như bình sơn, thuốc diệt côn trùng) thuộc loại rác nào? ", "A. Rác tái chế", "B. Rác thải nguy hại", "C. Rác hữu cơ", "D. Rác sinh hoạt thông thường" },
{ "Giấy thuộc phân loại rác nào trong “Mô hình 3” của UEH Go Green Station? ", "A. Giấy", "B. Rác tái chế", "C. Rác thải còn lại", "D. Nhựa tái chế" },
{ "Tốn bao nhiêu thời gian để phân hủy 1 chai nước làm từ nhựa PET ngoài tự nhiên ", "A. 100 - 500 năm để phân hủy hoàn toàn", "B. 450 - 1000 năm để phân hủy hoàn toàn", "C. 500 năm", "D. 100 năm" },
{ "Quy trình nào sau đây là quy trình tái chế nhựa? ", "A. Nghiền nhỏ, rửa sạch, nấu chảy, ép khuôn", "B. Đốt cháy, lọc khí, làm mát", "C. Phơi nắng, sấy khô, nghiền nát", "D. Rửa sạch, cắt nhỏ, chôn lấp, ủ phân" },
{ "Những vật dụng nào sau đây có thể dùng thủy tinh tái chế để chế tạo? ", "A. Chip máy tính", "B. Giấy", "C. Bê tông", "D. Sơn" },
{ "Nên chọn loại chai nhựa nào dưới đây để có thể sử dụng lại nhiều lần và giảm phát thải? ", "A. Chai nhựa nào cũng như nhau", "B. Chai nhựa PET", "C. Chọn loại chai nhựa rẻ nhất", "D. Chai nhựa HDPE" },
{ "Mô hình nào 3R được áp dụng cho dự án UEH Green Campus để phân loại và xử lý rác gồm các bước nào sau đây: ", "A. Rethink, refuse, reduce", "B. Reduce, reuse, recycle", "C. Rethink, reduce, responsibility", "D. Refuse, reduce, reuse" }
};

        string[] dapAnDung = { "A", "C", "B", "D", "B", "C", "A", "C", "B", "B", "D", "B", "C", "C", "C", "A", "A", "B", "B", "B", "B", "C", "D", "B", "B", "B", "A", "C", "D", "B" }; ; // Đáp án đúng


        int soCauHoi = cauhoi.GetLength(0); // Lưu số lượng câu hỏi vào biến
        int soVong = 3; // 3 vòng chơi
        int soCauHoiMoiVong = 5; // 5 câu hỏi mỗi vòng
        int tongDiem = 0;
        // Quá trình chơi
        for (int vong = 1; vong <= soVong; vong++)
        {
            //Bắt đầu đếm giờ 
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Biến kiểm tra quyền trợ giúp 50/50 trong mỗi vòng
            bool daSuDung5050 = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n--- Vòng {vong} ---");

            List<string> cauHoiCuaVong = new List<string>();
            int diem = 0;
            int diemTungVong = 0;
            int soThuTu = 1;

            //Chạy đồng hồ đếm ngược 30 giây

            int socaudaduoctraloi = 0;

            //Trộn chỉ số câu hỏi
            List<int> indexList = Enumerable.Range(0, soCauHoi).OrderBy(x => rand.Next()).ToList();
            for (int i = 0; i < soCauHoiMoiVong; i++)
            {
                if (stopWatch.Elapsed.TotalSeconds >= 30)
                {
                    break;
                }
                //List<int> indexList = Enumerable.Range(0, soCauHoi).OrderBy(x => rand.Next()).ToList();
                int index = indexList[i]; // Lấy chỉ số câu hỏi đã trộn
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n║Câu hỏi số {0}: {1}", i + 1, cauhoi[index, 0]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine(" {0}", cauhoi[index, 1]);
                Console.WriteLine(" {0}", cauhoi[index, 2]);
                Console.WriteLine(" {0}", cauhoi[index, 3]);
                Console.WriteLine(" {0}", cauhoi[index, 4]);
                Console.WriteLine($"╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
                if (!daSuDung5050)
                {
                    string chon5050 = " ";
                    while (true)
                    {
                        // Hỏi người chơi xem có muốn sử dụng 50/50 không
                        try
                        {

                            Console.WriteLine("\nBạn có muốn sử dụng quyền trợ giúp 50/50 không? (Y/N)");
                            chon5050 = Console.ReadLine()?.ToUpper();
                            if (chon5050 == "Y" || chon5050 == "N")
                                break;
                            else
                                throw new Exception("Mời bạn nhập đúng Y hoặc N");
                        }
                        catch (Exception loi)
                        {
                            Console.WriteLine(loi.Message);
                        }
                    }

                    //Kiểm tra quyền 50/50 chưa được sử dụng
                    if (chon5050 == "Y")
                    {
                        daSuDung5050 = true;
                        // Sử dụng quyền trợ giúp 50/50
                        List<string> options = new List<string> { cauhoi[index, 1], cauhoi[index, 2], cauhoi[index, 3], cauhoi[index, 4] };
                        string correctAnswer = cauhoi[index, dapAnDung[index] == "A" ? 1 : (dapAnDung[index] == "B" ? 2 : (dapAnDung[index] == "C" ? 3 : 4))];

                        UseFiftyFifty(options, correctAnswer);

                        // Hiển thị lại câu hỏi với 2 đáp án còn lại
                        Console.WriteLine("\nSau khi sử dụng quyền trợ giúp 50/50:");
                        DisplayOptions(options);

                    }
                }
                else //if (chon5050 == "Y")
                {
                    Console.WriteLine("Bạn đã sử dụng chức năng 50/50 cho vòng này rồi!");
                }

                // Nhập câu trả lời của người chơi
                string traloi = "";
                while (true)
                {
                    try
                    {
                        Console.Write("\nNhập câu trả lời của bạn (A/B/C/D): ");
                        traloi = Console.ReadLine()?.ToUpper();

                        if (traloi == "A" || traloi == "B" || traloi == "C" || traloi == "D")
                            break;
                        else
                            throw new Exception("Vui lòng chỉ nhập A, B, C hoặc D.");
                    }
                    catch (Exception loi)
                    {
                        Console.WriteLine(loi.Message);
                    }
                }

                if (traloi == dapAnDung[index])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bạn đã chọn đáp án đúng.");
                    diem++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sai rồi. Đáp án đúng là: {0}.", dapAnDung[index]);
                }

                //Nếu bạn hoàn thành đủ câu hỏi trước 30s
                if (i == 5)
                {
                    break;
                }

            }
            stopWatch.Stop();

            diemTungVong += diem;
            Console.WriteLine("\nBạn đã hoàn thành vòng {0} với số điểm: {1}/{2}", vong, diem, soCauHoiMoiVong);
            //Cộng điểm của vòng hiện tại vào tổng điểm
            tongDiem += diem;

            // Hàm trợ giúp để hiển thị các lựa chọn
            static void DisplayOptions(List<string> options)
            {
                char optionLetter = 'A';
                foreach (var option in options)
                {
                    if (!string.IsNullOrEmpty(option))
                    {

                        Console.WriteLine($" {option}");
                        optionLetter++;
                    }
                }
            }

            // Hàm trợ giúp để sử dụng quyền trợ giúp 50/50
            static void UseFiftyFifty(List<string> options, string correctAnswer)
            {
                // Xóa 2 câu trả lời sai (giữ lại câu trả lời đúng và 1 câu sai)
                List<string> wrongAnswers = options.Where(x => x != correctAnswer).OrderBy(x => Guid.NewGuid()).Take(2).ToList();
                foreach (var wrongAnswer in wrongAnswers)
                {
                    options.Remove(wrongAnswer);
                }
            }
        }
        Console.ReadKey();
        KetThucGame(tongDiem);
    }


    static int diem = 0;
    static int diemCaoNhat = 0;
    static void KetThucGame(int tongDiem)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t╔══════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("\t║                         TRÒ CHƠI KẾT THÚC                        ║");
        Console.WriteLine("\t╠══════════════════════════════════════════════════════════════════╣");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\t║ Điểm của bạn là: {tongDiem}                                         ║");

        if (tongDiem > diemCaoNhat)
        {
            diemCaoNhat = tongDiem;
        }
        //Thông báo điểm rèn luyện nếu điểm vượt mốc 10
        if (tongDiem > 10)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t║ Xin chúc mừng! Bạn đã nhận được 2 điểm rèn luyện.                ║");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t║ Rất tiếc. Bạn không nhận được điểm rèn luyện.                    ║");
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t╠══════════════════════════════════════════════════════════════════╣");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\t║ ĐIỂM CAO NHẤT: {diemCaoNhat}                                        ║");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t╚══════════════════════════════════════════════════════════════════╝");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\n\tNhấn Enter để quay lại bảng chọn, R để chơi lại, hoặc Tab để hiện Bảng xếp hạng.");
        Console.ResetColor();

        bool nenThoat = false;

        while (!nenThoat)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    nenThoat = true;
                    break;
                case ConsoleKey.Tab:
                    Bangxephang(); // Hiển thị bảng xếp hạng
                    Console.Clear(); // Xóa màn hình sau khi thoát khỏi bảng xếp hạng
                    Console.WriteLine("\n\tNhấn Enter để quay lại bảng chọn hoặc R để chơi lại.");
                    break;
                default:
                    if (keyInfo.KeyChar == 'r' || keyInfo.KeyChar == 'R') // Chơi lại
                    {
                        XuLyChoi();
                        nenThoat = true;
                    }
                    break;
            }
        }
        string filepath = "KetQuaChoi.txt";
        using (StreamWriter sw = new StreamWriter(filepath, true))
        {
            sw.WriteLine($"Tên người chơi: {nguoichoi}");
            sw.WriteLine($"Điểm: {tongDiem}");
            sw.WriteLine($"Ngày chơi: {DateTime.Now}");
            sw.WriteLine("======================================");
        }
        Console.WriteLine("Kết quả được lưu vào KetQuaChoi.txt");

    }
    public static void Bangxephang()
    {
        string filepath = "KetQuaChoi.txt";

        // Kiểm tra nếu file không tồn tại
        if (!File.Exists(filepath))
        {
            Console.WriteLine("Không có dữ liệu bảng xếp hạng.");
            return;
        }

        var lines = File.ReadAllLines(filepath);
        var scores = new List<(string Name, int Score, DateTime Date)>();

        // Duyệt qua từng nhóm 4 dòng
        for (int i = 0; i < lines.Length; i += 4)
        {
            try
            {
                string name = lines[i].Replace("Tên người chơi: ", "").Trim();
                int score = int.Parse(lines[i + 1].Replace("Điểm: ", "").Trim());
                DateTime date = DateTime.Parse(lines[i + 2].Replace("Ngày chơi: ", "").Trim());

                scores.Add((name, score, date));
            }
            catch
            {
                // Bỏ qua lỗi nếu dữ liệu không đúng định dạng
                continue;
            }
        }

        // Sắp xếp danh sách theo điểm giảm dần
        scores = scores.OrderByDescending(s => s.Score).ToList();

        // Hiển thị giao diện bảng xếp hạng
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("                                   BẢNG XẾP HẠNG                                    ");
        Console.WriteLine("  ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━  ");
        Console.WriteLine("   Tên người chơi             |    Điểm       |    Ngày chơi                       ");
        Console.WriteLine("  ────────────────────────────────────────────────────────────────────────────────  ");

        Console.ForegroundColor = ConsoleColor.White;

        int rank = 1;
        foreach (var score in scores.Take(10)) // Chỉ hiển thị top 10
        {
            Console.WriteLine($"   {rank++,-3} {score.Name,-25} {score.Score,-12} {score.Date:dd/MM/yyyy HH:mm}");
        }

        Console.WriteLine("\n  Nhấn phím bất kỳ để quay lại menu.");
        Console.ReadKey();
    }

}



