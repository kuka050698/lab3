using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    public class Snake:Drawer
    {
        public int MyProperty { get; set; } 

        public Snake()
        {
            sign = 'o';
        }

        public void Move(int dx, int dy)
        {

            for(int i = body.Count - 1; i > 0; --i)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }
            
            if(body[0].x + dx < 0) dx = dx + 48;// Граница Стены 
            if (body[0].y + dy < 0) dy = dy + 48;
            if (body[0].x + dx > 48) dx = dx - 48;
            if (body[0].y + dy > 48) dy = dy - 48;


            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;
            // тексеру; жие аламызба
            if(Game.snake.body[0].x == Game.food.body[0].x && Game.snake.body[0].y == Game.food.body[0].y)
            {
                Game.Eat++;
                if (Game.Eat % 4 == 0)
                {
                    Game.level++;
                    Console.Clear();
                    Console.WriteLine("Next");
                    Game.isActive = false;
                    Game.Init();
                    Game.LoadlLevel(Game.level); // безопасность
                }
                // жыланга жана точка костык; оседи
                Game.snake.body.Add(new Point { x = Game.food.body[0].x, y = Game.food.body[0].y });

                Game.food.body[0].x = new Random().Next(0, 15);
                Game.food.body[0].y = new Random().Next(0, 15);

                int tx = 0, ty = 0;
                bool exel = false;
                while (!exel) 
                {
                    tx = new Random().Next(15, 28); 
                    ty = new Random().Next(15, 28);

                    exel = true;
                    for(int i=0; i<Game.wall.body.Count; ++i)
                    {
                        if (tx == Game.wall.body[i].x && ty == Game.wall.body[i].y) // жарга согысатын болса рандомный жерде атып шык
                        {
                            exel = false;
                            break;
                        }
                    }
                }

            }

            for (int i = 0; i < Game.wall.body.Count; ++i) // тугел жарман журип шыгамыз
            {
                if (Game.snake.body[0].x == Game.wall.body[i].x && Game.snake.body[0].y == Game.wall.body[i].y)
                {
                    Console.Clear();
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("Game over!");
                    Game.isActive = false; // токтатып тастайды
                }
            }

        }
    }
}
