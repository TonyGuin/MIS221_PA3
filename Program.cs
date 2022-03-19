using System;
using System.Threading; //Needed for my delay in the game graphics

namespace MIS221_PA3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Menu();
        }


        static void Menu()
        {
            int credits = 0;
            ContinueGame(ref credits); //gets credits if you are continuing a past game
           bool test = true; //Pre test
           while(test == true && credits != 0 && credits <300) //this will prompt a loss if you run out of credits or get too many
            {
                DisplayMenu(credits);
                string userInput = Console.ReadLine();
                System.Console.WriteLine();//to make the terminal easier to read
                while(userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5")
                {
                    DisplayMenu(credits);   
                    userInput = Console.ReadLine(); 
                    System.Console.WriteLine();//to make the terminal easier to read
                }
                if(userInput == "1")
                {
                    TheForceMenu(ref credits);
                }
                else if (userInput == "2")
                {
                    BlastersMenu(ref credits);
                }
                else if (userInput == "3")
                {
                    SeeScoreboard(credits);
                }
                else if(userInput == "4")
                {
                    BothDescriptionsAndExamples();
                }
                else
                {
                    test = false;
                }
             }
            if(credits ==0 )
            {
                Console.Clear();
                System.Console.WriteLine("Looser! You lost all your credits!\n\n"); //final display message possibility
            }
            else if(credits >= 300 )
            {
                Console.Clear();
                System.Console.WriteLine("WINNER WINNER CHICKEN DINNER\nThanks for playing!");
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("Thanks for playing! Remember that your credits were {0}. Enter this next time you play to continue where you left off!\n\n", credits);
            }       //final display message possibility
        }



         static void ContinueGame(ref int credits) //Bounus!!!
         {
            System.Console.WriteLine("Enter 1 to start a new game");
            Console.WriteLine("Enter 2 to start where you left off");
             string userInput = Console.ReadLine();
            System.Console.WriteLine();//to make the terminal easier to read
             while(userInput != "1" && userInput != "2" )
                {
                    Console.Clear();
                    System.Console.WriteLine("Enter 1 to start a new game\nEnter 2 to start where you left off");
                    userInput = Console.ReadLine();
                    System.Console.WriteLine();//to make the terminal easier to read
                }
            if(userInput == "1")
                {
                    credits = 50;
                }
            else
                {
                    Console.Clear();
                    System.Console.WriteLine("Please eneter the amount of credits from last game: 1-299");
                    string userNum = Console.ReadLine(); //credits they want
                    System.Console.WriteLine();//to make the terminal easier to read
                    bool validInput =  true;
                    int creditInt = 0; //credits they wanted turned into an in int if While loop that follows passes
                    while(validInput) //While loop to test if input is valid interger within a range
                    {
                        if(int.TryParse(userNum, out creditInt)) // returns true and gives out int value
                        {
                            if( 0<creditInt &&  creditInt<300 )
                            {
                                validInput = false;
                            }
                            else
                            {
                                Console.Clear();
                                 System.Console.WriteLine("Please eneter the amount of credits from last game: 1-299");
                                 userNum = Console.ReadLine();
                                System.Console.WriteLine();//to make the terminal easier to read
                            }

                        }
                        else
                        {
                            Console.Clear();
                             System.Console.WriteLine("Please eneter the amount of credits from last game: 1-299");
                             userNum = Console.ReadLine();
                             System.Console.WriteLine();//to make the terminal easier to read
                                 
                        }

                    }
                    credits = creditInt;
                }
         }





         static void DisplayMenu(int credits)
         {
            Console.Clear();
            System.Console.WriteLine("You currently have {0} credits", credits);
            System.Console.WriteLine("Reach 300 to win the game!\n");
            System.Console.WriteLine("Enter 1 to play 'The Force'");
            System.Console.WriteLine("Enter 2 to play 'Blasters'");
            System.Console.WriteLine("Enter 3 to play see scoreboard");
            System.Console.WriteLine("Enter 4 to see descriptions and examples of both games");
            System.Console.WriteLine("Enter 5 to exit");
         }
































         static void TheForceMenu(ref int credits)
         {
            bool test = true;
            while(test == true && credits != 0 && credits < 300 )
            {
                TheForceOptions();
                System.Console.WriteLine("enter 1 to play\nenter 2 to leave");
                string userInput = Console.ReadLine();
                System.Console.WriteLine();//to make the terminal easier to read
                while(userInput != "1" && userInput != "2")
                {
                    TheForceOptions();  
                    System.Console.WriteLine("enter 1 to play\nenter 2 to leave");
                    userInput = Console.ReadLine(); 
                    System.Console.WriteLine();//to make the terminal easier to read
                }
                if(userInput == "1")
                {
                    TheForce(ref credits);
                }
                else
                {
                    test = false; // leave game
                }
            }

         }
         static void TheForceOptions()
         {
             Console.Clear();
             System.Console.WriteLine("'The Force'\nIn this game a card will be displayed. Your goal is to guess the relationship of the next card.");
             System.Console.WriteLine("Getting through a certain number of correct guesses will pay out differently\n\n1-3 correct guesses results in loosing your wager");
             System.Console.WriteLine("4 to 5 correct guesses breaks even\n6-8 correct guesses doubles your wager amount (risking 10 results in a net gain of 10) ");
             System.Console.WriteLine("9 correct guesses means you completed all 10 cards! THIS TRIPLES YOUR WAGER!!!(risking 10 results in a net gain of 20)\n(note, A is considered 1)\n\n\n");
         }

         static void TheForce(ref int credits)
        {
            if(credits <= 0) //code should not be called but this is just for saftey
            {
                System.Console.WriteLine("You can not play this game. You do not have enough credits");
            }
            else
            {

                System.Console.WriteLine("Your credits are {0}. How many would you like to bet?", credits);
                int userBet = -1;
                TheForceGameBetCheck(ref userBet, credits);
                int gameOutcome = TheForceGamePlay();
                switch(gameOutcome)
                {
                    case 1: //looses money bet 
                    {
                        credits -= userBet;
                        System.Console.WriteLine("you lost {0}, your credits are now {1}.\n", userBet, credits);
                        for(int i=0;i<3;i++)
                        {
                            Delay(); //Delay before the next game begins
                        }
                    }
                    break;
                    case 2: //breaks even
                    {
                        System.Console.WriteLine("you broke even, your credits are still {0}.\n", credits);
                        for(int i=0;i<3;i++)
                        {
                            Delay(); //Delay before the next game begins
                        }

                    }
                    break;
                    case 3: //doubles money bet
                    {
                        credits += (userBet);
                        System.Console.WriteLine("you doubled your bet credits of {0}, your credits are now {1}.\n", userBet, credits);
                        for(int i=0;i<3;i++)
                        {
                            Delay(); //Delay before the next game begins
                        }

                    }
                    break;
                    case 4: // triples money bet
                    {
                        credits += (userBet*2);
                        System.Console.WriteLine("you tripled your bet credits of {0}, your credits are now {1}.\n", userBet, credits);
                        for(int i=0;i<3;i++)
                        {
                            Delay(); //Delay before the next game begins
                        }

                    }
                    break;
                }

            }

        }

        static void TheForceGameBetCheck(ref int userBet, int credits) //Checks and makes sure the bet is valid
        {
            string userNum = Console.ReadLine(); //credits they want to bet
                    System.Console.WriteLine();//to make the terminal easier to read
                    bool validInput =  false;
                    int creditInt = 0; //credits they wanted to bet turned into an in int if the While loop that follows passes
                    while(!validInput) //While loop to test if input is valid interger within a range
                    {
                        if(int.TryParse(userNum, out creditInt)) // returns true and gives out int value
                        {
                            if( 0<creditInt &&  creditInt<300  && creditInt <= credits)
                            {
                                validInput = true;
                            }
                            else
                            {
                                 System.Console.WriteLine("please enter a valid number of credits to bet");
                                 userNum = Console.ReadLine();
                                System.Console.WriteLine();//to make the terminal easier to read
                            }

                        }
                        else
                        {
                             System.Console.WriteLine("please enter a valid number of credits to bet");
                             userNum = Console.ReadLine();
                             System.Console.WriteLine();//to make the terminal easier to read
                                 
                        }

                    }
                    userBet = creditInt;
        }

















        static int TheForceGamePlay()
        {
            int gameOutcome = 0; //1 means lose, 2 means break even, 3 means double, 4 means triple. gives ability to see outcome
            int cardSubCount = -1;
            int gameCount = 0;
            bool winning = true;
            int[] theForceCard = new int[11];

            while(cardSubCount < 9 && winning) //if you get your ninth correct, your out of cards
            {
                if (cardSubCount == -1)
                {
                    GetRandomCardNum(theForceCard);
                    cardSubCount++; //no longer first card 
                }
                int currentCard = -1;
                int nextCard = -1;

                TheForcePrepareDisplayCardsBeforeGuess(theForceCard,cardSubCount, ref currentCard,ref nextCard); //display cards before guess
                DisplayTheForceAmountCorrect(cardSubCount);
                DisplayTheForceInGameRules();
                string userGuess = Console.ReadLine();
                TheForceUserGuessCheck(ref userGuess);
                cardSubCount++;
                TheForcePrepareDisplayCardsAfterGuess(theForceCard,cardSubCount, ref currentCard,ref nextCard); //too early
                
                TheForceCardsWithoutSuit(ref currentCard, ref nextCard);

                System.Console.WriteLine("\nyou guessed " +userGuess);

                if(userGuess == "high")
                {
                    if (nextCard > currentCard)
                    {
                        Console.WriteLine("\nthe card was higher");
                        for(int i=0;i<3;i++)
                        {
                            Delay(); //Delay before the next attempt begins
                        }
                        
                        gameCount ++;
                    }
                    else
                    {
                        Console.WriteLine("\nthe card was not higher");
                        for(int i=0;i<3;i++)
                        {
                            Delay(); //Delay before the next attempt begins
                        }
                        winning = false;
                    }
                }
                else
                {
                    if(nextCard < currentCard)
                    {
                        Console.WriteLine("\nthe card was lower");
                        for(int i=0;i<3;i++)
                        {
                            Delay(); //Delay before the next attempt begins
                        }
                        
                        gameCount++;
                    }
                    else
                    {
                        Console.WriteLine("\nthe card was not lower");
                        for(int i=0;i<3;i++)
                        {
                            Delay(); //Delay before the next attempt begins
                        }
                        winning = false;
                    }
                }
            }
            if(gameCount <= 3)
            {
                gameOutcome = 1; //gives range of loss; 1 = loss bet
            }
            else if (gameCount <= 5)
            {
                gameOutcome = 2; //gives range of loss; 2  = break even
            }
            else if (gameCount <= 8)
            {
                gameOutcome = 3; //gives range of loss; 3 = bet *2
            }
            else if (gameCount == 9)
            {
                gameOutcome = 4; //gives max win; 4 = bet *3
            }
            return gameOutcome;


        }
        static void DisplayTheForceInGameRules()
        {
            System.Console.WriteLine("\nEnter 'high' if you think the next card will be higher than the one displayed");
            System.Console.WriteLine("Enter 'low' if you think the next card will be lower than the one displayed");
            System.Console.WriteLine("If it is the same, you loose!\n");
        }

        static void  DisplayTheForceAmountCorrect(int cardSubCount)
        {
            System.Console.WriteLine("You have gotten {0} correct so far\n", cardSubCount);
        }

        static void TheForceUserGuessCheck(ref string userGuess)
        {
            while(userGuess.ToLower() != "high" && userGuess.ToLower() != "low")
            {
                System.Console.WriteLine("check your spelling. Enter 'high' or 'low'.");
                userGuess = Console.ReadLine();
            }
            userGuess = userGuess.ToLower();

        }





























        static void GetRandomCardNum(int[] theForceCard)
        {

            int count = 0;
            Random rnd = new Random();

            while(count <= 9)
            {
                theForceCard[count] = rnd.Next(1,53);
                if(count > 0)
                {
                    for(int i = 1; i<=count; i++)
                    {
                        while( theForceCard[count] == theForceCard[count+(-i)])
                        {
                            i = 1;
                            theForceCard[count] = rnd.Next(1,53);  //if card is a repeat, a new card is given and the checking process 
                                                                    //is restarted for that card
                        }
                    }
                }
                count++;
            }


            // for(int k=0; k < count; k++)
            // {
            //     System.Console.WriteLine(theForceCard[k]);
            // }

            // for(int k = 0; k <= count-1; k++)
            // {
            //     System.Console.WriteLine(theForceCard[k]);
            // }





            // count++;
            // theForceCard[count] = rnd.Next(1,53);
            // for(int i = 0; i<=count; i++)
            // {
            //     if(i == 0)
            //     {
            //         i++;
            //     }
            //     while( theForceCard[count] == theForceCard[count+(-i)])
            //     {
            //         i = 1;
            //         theForceCard[count] = rnd.Next(1,53);
            //     }
            // }
          
            
        }





























        static void TheForcePrepareDisplayCardsBeforeGuess(int[] theForceCard,int cardSubCount, ref int currentCard, ref int nextCard)
        {
            Console.Clear();
            for(int i = 0; i<= cardSubCount; i++) //first card will be 0
            {
                int theForceCardInt = theForceCard[i];
                TheForceGraphicDisplay(theForceCardInt); //displays the card
            }
            if(cardSubCount >= 0)
                {
                    currentCard = theForceCard[cardSubCount]; //prepares for the guess
                    nextCard = theForceCard[cardSubCount+1];
                }
        }

        static void TheForcePrepareDisplayCardsAfterGuess(int[] theForceCard,int cardSubCount, ref int currentCard, ref int nextCard)
        {
            Console.Clear();
            if(cardSubCount<11)
            {
                Console.Clear();
                for(int i = 0; i<= cardSubCount; i++)
                {
                    int theForceCardInt = theForceCard[i];
                    TheForceGraphicDisplay(theForceCardInt); //displays the card
                }
            }
        }



        static void TheForceCardsWithoutSuit(ref int currentCard, ref int nextCard)
        {
            if(currentCard <=4 )
                currentCard = 1;
            else if(currentCard <= 8)
                currentCard = 2;
            else if(currentCard <= 12)
                currentCard = 3;
            else if(currentCard <= 16)
                currentCard = 4;
            else if(currentCard <= 20)
                currentCard = 5;
            else if(currentCard <= 24)
                currentCard = 6;
            else if(currentCard <= 28)
                currentCard = 7;
            else if(currentCard <= 32)
                currentCard = 8;
            else if(currentCard <= 36)
                currentCard = 9;
            else if(currentCard <= 40)
                currentCard = 10;
            else if(currentCard <= 44)
                currentCard = 11;
            else if(currentCard <= 48)
                currentCard = 12;
            else if(currentCard <= 52)
                currentCard = 13;
            if(nextCard <=4 )
                nextCard = 1;
            else if(nextCard <= 8)
                nextCard = 2;
            else if(nextCard <= 12)
                nextCard = 3;
            else if(nextCard <= 16)
                nextCard = 4;
            else if(nextCard <= 20)
                nextCard = 5;
            else if(nextCard <= 24)
                nextCard = 6;
            else if(nextCard <= 28)
                nextCard = 7;
            else if(nextCard <= 32)
                nextCard = 8;
            else if(nextCard <= 36)
                nextCard = 9;
            else if(nextCard <= 40)
                nextCard = 10;
            else if(nextCard <= 44)
                nextCard = 11;
            else if(nextCard <= 48)
                nextCard = 12;
            else if(nextCard <= 52)
                nextCard = 13;
            
        }



        static void TheForceGraphicDisplay(int theForceCardInt)
        {
            switch (theForceCardInt)
            {
                case 1:
                    TheForceGraphicAS();
                    break;
                case 2:
                    TheForceGraphicAH();
                    break;
                case 3:
                    TheForceGraphicAD();
                    break;
                case 4:
                    TheForceGraphicAC();
                    break;
                case 5:
                    TheForceGraphic2C();
                    break;
                case 6:
                    TheForceGraphic2D();
                    break;
                case 7:
                    TheForceGraphic2H();
                    break;
                case 8:
                    TheForceGraphic2S();
                    break;
                case 9:
                    TheForceGraphic3C();
                    break;
                case 10:
                    TheForceGraphic3D();
                    break;
                case 11:
                    TheForceGraphic3H();
                    break;
                case 12:
                    TheForceGraphic3S();
                    break;
                case 13:
                    TheForceGraphic4C();
                    break;
                case 14:
                    TheForceGraphic4D();
                    break;
                case 15:
                    TheForceGraphic4H();
                    break;
                case 16:
                    TheForceGraphic4S();
                    break;
                case 17:
                    TheForceGraphic5C();
                    break;
                case 18:
                    TheForceGraphic5D();
                    break;
                case 19:
                    TheForceGraphic5H();
                    break;
                case 20:
                    TheForceGraphic5S();
                    break;
                case 21:
                    TheForceGraphic6C();
                    break;
                case 22:
                    TheForceGraphic6D();
                    break;
                case 23:
                    TheForceGraphic6H();
                    break;
                case 24:
                    TheForceGraphic6S();
                    break;
                case 25:
                    TheForceGraphic7C();
                    break;
                case 26:
                    TheForceGraphic7D();
                    break;
                case 27:
                    TheForceGraphic7H();
                    break;
                case 28:
                    TheForceGraphic7S();
                    break;
                case 29:
                    TheForceGraphic8C();
                    break;
                case 30:
                    TheForceGraphic8D();
                    break;
                case 31:
                    TheForceGraphic8H();
                    break;
                case 32:
                    TheForceGraphic8S();
                    break;
                case 33:
                    TheForceGraphic9C();
                    break;
                case 34:
                    TheForceGraphic9D();
                    break;
                case 35:
                    TheForceGraphic9H();
                    break;
                case 36:
                    TheForceGraphic9S();
                    break;
                case 37:
                    TheForceGraphic10C();
                    break;
                case 38:
                    TheForceGraphic10D();
                    break;
                case 39:
                    TheForceGraphic10H();
                    break;
                case 40:
                    TheForceGraphic10S();
                    break;
                case 41:
                    TheForceGraphicJC();
                    break;
                case 42:
                    TheForceGraphicJD();
                    break;
                case 43:
                    TheForceGraphicJH();
                    break;
                case 44:
                    TheForceGraphicJS();
                    break;
                case 45:
                    TheForceGraphicQC();
                    break;
                case 46:
                    TheForceGraphicQD();
                    break;
                case 47:
                    TheForceGraphicQH();
                    break;
                case 48:
                    TheForceGraphicQS();
                    break;
                case 49:
                    TheForceGraphicKC();
                    break;
                case 50:
                    TheForceGraphicKD();
                    break;
                case 51:
                    TheForceGraphicKH();
                    break;
                case 52:
                    TheForceGraphicKS();
                    break;
            }
        }




































        static void BlastersMenu(ref int credits)
        {
            bool test = true;
            while(test && credits > 0 && credits < 300)
            {
                Console.Clear();
                BlastersOptions();
                System.Console.WriteLine("enter 1 to play\nenter 2 to leave");
                string userInput = Console.ReadLine();
                System.Console.WriteLine();//to make the terminal easier to read
                while(userInput != "1" && userInput != "2")
                {
                    System.Console.WriteLine("Enter either 1 or 2");  
                    userInput = Console.ReadLine(); 
                    System.Console.WriteLine("");//to make the terminal easier to read
                }
                if(userInput == "1")
                {
                    Blasters(ref credits);
                }
                else
                {
                    test = false;
                }
            }
        }

        static void BlastersOptions()
        {
            System.Console.WriteLine("'Blasters'\nIn this game you are shot at by Yoda. Your goal is not to be hit!");
            System.Console.WriteLine("Starting with 15 points, this game requires you to reach 40 points to win.");
            System.Console.WriteLine("Winning doubles your wager, while failing at any point looses the wager ");
            System.Console.WriteLine("You will have the follwoing options to attempt to dodged the shot\n");
            System.Console.WriteLine("Dodge: Works 50% of the time");
            System.Console.WriteLine("\tSucess grants you 5 points, failure results in a loss of 5 points");
            System.Console.WriteLine("Deflect: Works 30% of the time");
            System.Console.WriteLine("\tSucess grants your 10 points, failure results in a loss of 5 points\n\n\n");
        }

        static void Blasters(ref int credits)
        {
            if(credits <= 19)
            {
                Console.Clear();
                System.Console.WriteLine("You can not play this game. You do not have enough credits");
                for(int i=0;i<4;i++)
                {
                    Delay(); //Delay before the next game begins
                }
            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("Your credits are {0}. How many would you like to bet? (Minimum of 20)", credits);
                int userBet = -1;
                BlastersGameBetCheck(ref userBet, credits);
                int gameOutcome = BlastersGamePlay(); // 1 means win(reached 40 points) 0 means loss by quiting or running out of points
                if(gameOutcome == 0)
                {
                    credits -= userBet;
                    System.Console.WriteLine("you lost {0} credits, your credits are now {1}.\n", userBet, credits);

                }
                else
                {
                    credits += userBet;
                    System.Console.WriteLine("you won, your credits are now {0}.\n", credits);
                    Delay();
                    Delay();
                }


            }
        }

        static void BlastersGameBetCheck(ref int userBet, int credits) //Checks and makes sure the bet is valid
        {
            string userNum = Console.ReadLine(); //credits they want to bet
                    System.Console.WriteLine();//to make the terminal easier to read
                    bool validInput =  false;
                    int creditInt = 0; //credits they wanted to bet turned into an in int if the While loop that follows passes
                    while(!validInput) //While loop to test if input is valid interger within a range
                    {
                        if(int.TryParse(userNum, out creditInt)) // returns true and gives out int value
                        {
                            if( creditInt>=20 &&  creditInt<300  && creditInt <= credits)
                            {
                                validInput = true;
                            }
                            else
                            {
                                 System.Console.WriteLine("please enter a valid number of credits to bet\n");
                                 userNum = Console.ReadLine();

                            }

                        }
                        else
                        {
                             System.Console.WriteLine("please enter a valid number of credits to bet\n");
                             userNum = Console.ReadLine();

                                 
                        }

                    }
                    userBet = creditInt;
        }

        static int BlastersGamePlay()
        {
            int points = 15;
            int blastersGameOutcome;
            bool playAgain = true;
            while(points >=5 && points <=39 && playAgain) // in game rquirements to keep playing
            {
                BlastersGraphicStart();
                System.Console.WriteLine("Yoda just shot at you! Act fast!\nWhat action are you going to take?\n");
                DisplayBlastersInGameRules();
                System.Console.WriteLine("\tYour point total is {0}\n", points);
                string userInput = Console.ReadLine();
                BlasterUserGuessCheck(ref userInput);
                if(userInput == "deflect")
                {
                    int deflectNum = 0;
                    int deflectNumChance = DeflectChance(); // gets value 0 or 1. 0 happing at 30% chance
                    if(deflectNum == deflectNumChance) //if 0 = 0
                    {
                        BlastersGraphicDeflectSucess();
                        System.Console.WriteLine("\n\n\tYou deflected his shot");
                        points += 10;
                        System.Console.WriteLine("You just gained 10 points, Now you have {0}\n ",points);
                        for(int i=0;i<4;i++)
                        {
                            Delay(); //Delay before the next game begins
                        }
                        
                    }
                    else
                    {
                        BlastersGraphicDeflectFail();
                        System.Console.WriteLine("\n\n\tyou failed to deflect his shot\n");
                        points -= 5;
                        System.Console.WriteLine("You just lost 5 points, Now you have {0}\n ",points);
                        for(int i=0;i<4;i++)
                        {
                            Delay(); //Delay before the next game begins
                        }
                        

                    }
                }
                else if(userInput == "dodge")
                {
                    int dodgeNum = 0; 
                    int dodgeNumChance = DodgeChance(); //gets value 0 or 1 at 50% odds
                    if(dodgeNum == dodgeNumChance) // if 0 = 0
                    {
                        BlastersGraphicDodgeSucess();
                        System.Console.WriteLine("\n\n\tYou dodged his shot");
                        points += 5;
                        System.Console.WriteLine("You just gained 5 points. Now you have {0}\n ",points);
                        for(int i=0;i<4;i++)
                        {
                            Delay(); //Delay before the next game begins
                        }
                    }
                    else
                    {
                        BlastersGraphicDodgeFail();
                        System.Console.WriteLine("\n\n\tyou failed to dodge his shot\n");
                        points -= 5;
                        System.Console.WriteLine("You just lost 5 points, Now you have {0}\n ",points);
                        for(int i=0;i<4;i++)
                        {
                            Delay(); //Delay before the next game begins
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Quitting now results in an AUTOMATIC LOSS. You will loose your credits bet.\nEnter 1 to keep playing \nEnter 2 to exit");
                    string quitOrStay = Console.ReadLine();
                    while(quitOrStay != "1" && quitOrStay != "2")
                    {
                        System.Console.WriteLine("\nQuitting now results in an AUTOMATIC LOSS. You will loose your credits bet.\nEnter 1 to keep playing \nEnter 2 to exit");
                        quitOrStay = Console.ReadLine();
                    }
                    if( quitOrStay == "1")
                    {
                        playAgain = true;
                    }
                    else
                    {
                        playAgain = false;
                    }

                }

            }
            if(points <= 0) //sees why program stoped running
            {
                blastersGameOutcome = 0; // game outcome
            }
            else if(points >=40) //sees why program stoped running
            {
                blastersGameOutcome = 1; // game outcome
            }
            else //sees why program stoped running
            {
                blastersGameOutcome = 0; // game outcome
            }
            return blastersGameOutcome;

        }
        static int DodgeChance()
        {
            int dodgeNumChance;
            Random rnd = new Random();
            int num = rnd.Next(0,2);
            if(num == 0)
            {
                dodgeNumChance = 0; //0 means he dodged it
            }
            else
            {
                dodgeNumChance = 1; //1 means he got hit
            }
            return dodgeNumChance;
        }

        static int DeflectChance()
        {
            int deflectNumChance;
            Random rnd = new Random();
            int num = rnd.Next(1,11);
            if(num <= 3)
            {
                deflectNumChance = 0; //0 means he dodged it
            }
            else
            {
                deflectNumChance = 1; //1 means he got hit
            }
            return deflectNumChance;
        }



        static void DisplayBlastersInGameRules()
        {
            System.Console.WriteLine("Enter 'deflect' to attempt to deflect the shot\nEnter 'dodge' to attempt to dodge the shot\nEnter 'exit' to quit");
        }

         static void BlasterUserGuessCheck(ref string userInput)
        {
            while(userInput.ToLower() != "deflect" && userInput.ToLower() != "dodge"&& userInput.ToLower() != "exit") //checks input
            {
                System.Console.WriteLine("check your spelling. Enter 'deflect' or 'dodge' or 'exit'.");
                userInput = Console.ReadLine();
                System.Console.WriteLine();//to make the terminal easier to read
            }
            if(userInput.ToLower() == "deflect")
            {
                userInput = userInput.ToLower();
            }
            else if (userInput.ToLower() == "dodge")
            {
                userInput = userInput.ToLower();
            }
            else
            {
                userInput = userInput.ToLower();
            }

        }

            

































        static void SeeScoreboard(int credits)
        {
            bool stay = true;
            while (stay)
            {
                Console.Clear();
                int creditsNeeded = 300 - credits;
                System.Console.WriteLine("Credit count currently: {0}. You still need {1} to WIN THE GAME!\n\n\n", credits, creditsNeeded);
                System.Console.WriteLine("Enter 1 to return to menu");
                string userInput = Console.ReadLine();
                while(userInput != "1")
                {
                    Console.Clear();
                    System.Console.WriteLine("Credit count currently: {0}. You still need {1} to WIN THE GAME!\n\n\n", credits, creditsNeeded);
                    System.Console.WriteLine("Enter 1 to return to menu");
                    userInput = Console.ReadLine();
                }
                if( userInput == "1")
                {
                    stay = false;
                }
            }
        }  



































        static void BothDescriptionsAndExamples()
        {
            bool stay = true;
            while (stay)
            {
                TheForceOptions(); //forceoptions already has console clear
                BlastersOptions(); //console clear is in the blastersmenu so this is not interferring
                System.Console.WriteLine("Enter 1 to view exapmles\nEnter 2 to return to menu");
                string userInput = Console.ReadLine();
                while(userInput != "1" && userInput != "2")
                {
                    System.Console.WriteLine("Enter 1 to view exapmles\nEnter 2 to return to menu");
                    userInput = Console.ReadLine();
                }
                if( userInput == "1")
                {
                    Console.Clear();
                    GameExamples();
                }
                else
                {
                    stay = false;
                }

            
            }
        }



        static void GameExamples()
        {
            bool stay = true;
            while(stay)
            {
                System.Console.WriteLine("Enter 1 to view 'The Force' example\nEnter 2 to view 'Blasters' example\nEnter 3 To exit");
                string userInput = Console.ReadLine();
                while(userInput != "1" && userInput != "2" && userInput != "3")
                {
                    Console.Clear();
                    System.Console.WriteLine("Enter 1 to view 'The Force' example\nEnter 2 to view 'Blasters' example\nEnter 3 To exit");
                    userInput = Console.ReadLine();
                }
                if( userInput == "1")
                {
                    ExampleOfTheForce();
                }
                else if( userInput == "2")
                {
                    ExampleOfBlasters();
                }
                else
                {
                    stay = false;
                }

            }
        }



        static void ExampleOfTheForce()
        {
            Console.Clear();
            System.Console.WriteLine("This is the example gameplay of 'The Force'\nThis is an automated system. Please wait until the end.");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            System.Console.WriteLine("This is the first card");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            TheForceGraphic10H();
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            System.Console.WriteLine("\nYou will be prompted to enter 'high' or 'low'");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            System.Console.WriteLine("\nLets say you chose 'low'");
            for(int i=0;i<3;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            TheForceGraphic10H();
            TheForceGraphic2D();
            System.Console.WriteLine("\n You would now attempt again");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            System.Console.WriteLine("\nYou will be prompted to enter 'high' or 'low'");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            System.Console.WriteLine("\nLets say you chose 'high'");
            for(int i=0;i<3;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            TheForceGraphic10H();
            TheForceGraphic2D();
            TheForceGraphic8D();
            System.Console.WriteLine("\n You would now attempt again");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            System.Console.WriteLine("\nYou will be prompted to enter 'high' or 'low'");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            System.Console.WriteLine("\nLets say you chose 'high'");
            for(int i=0;i<3;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            TheForceGraphic10H();
            TheForceGraphic2D();
            TheForceGraphic8D();
            TheForceGraphic4S();
            System.Console.WriteLine("\n You would have lost");
            for(int i=0;i<6;i++)
            {
                Delay(); //Delay before the next game begins
            }
            System.Console.WriteLine("\n\nBecause you only achieved 2 correct, you would have lost your wager.");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();


        }

        static void ExampleOfBlasters()
        {
            Console.Clear();
            System.Console.WriteLine("This is the example gameplay of 'Blasters'\nThis is an automated system. Please wait until the end.");
            for(int i=0;i<5;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            System.Console.WriteLine("This will be the startup display");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            BlastersGraphicStart();
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            System.Console.WriteLine("This will be the dodge sucess display");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            BlastersGraphicDodgeSucess();
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            System.Console.WriteLine("This will be the dodge fail display");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            BlastersGraphicDodgeFail();
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            System.Console.WriteLine("This will be the deflect sucess display");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            BlastersGraphicDeflectSucess();
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();
            System.Console.WriteLine("This will be the deflect fail display");
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            BlastersGraphicDeflectFail();
            for(int i=0;i<4;i++)
            {
                Delay(); //Delay before the next game begins
            }
            Console.Clear();

        }
































//The force graphics

        static void TheForceGraphicAS()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| A♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤A_|");
        }
        static void TheForceGraphicAH()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| A♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡A_|");
        }
        static void TheForceGraphicAC()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| A♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧A_|");
        }
        static void TheForceGraphicAD()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| A⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦A_|");
        }
        static void TheForceGraphic2S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 2♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤2_|");
        }
        static void TheForceGraphic2H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 2♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡2_|");
        }
        static void TheForceGraphic2C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 2♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧2_|");
        }
        static void TheForceGraphic2D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 2⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦2_|");
        }
        static void TheForceGraphic3S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 3♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤3_|");
        }
        static void TheForceGraphic3H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 3♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡3_|");
        }
        static void TheForceGraphic3C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 3♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧3_|");
        }
        static void TheForceGraphic3D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 3⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦3_|");
        }
        static void TheForceGraphic4S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 4♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤4_|");
        }
        static void TheForceGraphic4H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 4♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡4_|");
        }
        static void TheForceGraphic4C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 4♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧4_|");
        }
        static void TheForceGraphic4D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 4⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦4_|");
        }
        static void TheForceGraphic5S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 5♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤5_|");
        }
        static void TheForceGraphic5H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 5♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡5_|");
        }
        static void TheForceGraphic5C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 5♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧5_|");
        }
        static void TheForceGraphic5D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 5⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦5_|");
        }
        static void TheForceGraphic6S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 6♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤6_|");
        }
        static void TheForceGraphic6H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 6♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡6_|");
        }
        static void TheForceGraphic6C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 6♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧6_|");
        }
        static void TheForceGraphic6D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 6⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦6_|");
        }
        static void TheForceGraphic7S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 7♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤7_|");
        }
        static void TheForceGraphic7H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 7♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡7_|");
        }
        static void TheForceGraphic7C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 7♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧7_|");
        }
        static void TheForceGraphic7D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 7⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦7_|");
        }
        static void TheForceGraphic8S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 8♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤8_|");
        }
        static void TheForceGraphic8H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 8♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡8_|");
        }
        static void TheForceGraphic8C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 8♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧8_|");
        }
        static void TheForceGraphic8D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 8⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦8_|");
        }
        static void TheForceGraphic9S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 9♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤9_|");
        }
        static void TheForceGraphic9H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 9♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡9_|");
        }
        static void TheForceGraphic9C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 9♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧9_|");
        }
        static void TheForceGraphic9D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| 9⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦9_|");
        }
        static void TheForceGraphic10S()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("|10♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤10|");
        }
        static void TheForceGraphic10H()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("|10♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡10|");
        }
        static void TheForceGraphic10C()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("|10♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧10|");
        }
        static void TheForceGraphic10D()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("|10⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦10|");
        }
        static void TheForceGraphicJS()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| J♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤J_|");
        }
        static void TheForceGraphicJH()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| J♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡J_|");
        }
        static void TheForceGraphicJC()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| J♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧J_|");
        }
        static void TheForceGraphicJD()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| J⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦J_|");
        }
        static void TheForceGraphicQS()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| Q♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤Q_|");
        }
        static void TheForceGraphicQH()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| Q♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡Q_|");
        }
        static void TheForceGraphicQC()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| Q♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧Q_|");
        }
        static void TheForceGraphicQD()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| Q⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦Q_|");
        }
        static void TheForceGraphicKS()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| K♤  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♤K_|");
        }
        static void TheForceGraphicKH()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| K♡  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♡K_|");
        }
        static void TheForceGraphicKC()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| K♧  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__♧K_|");
        }
        static void TheForceGraphicKD()
        {
            System.Console.WriteLine(" _____");
            System.Console.WriteLine("| K⬦  |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|     |");
            System.Console.WriteLine("|__⬦K_|");
        }

//End of the force graphics

























//Start of Blasters Graphics
        static void BlastersGraphicStart()
        {
            int count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("•      -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o ");
                System.Console.WriteLine(" •     -|-");
                System.Console.WriteLine("        ^ ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("  •    -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("   •   -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("    •  -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
            }


        }
        static void BlastersGraphicDodgeSucess()
        {
            int count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("    •  -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("       -|-");
                System.Console.WriteLine("     •  ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("        o");
                System.Console.WriteLine("       -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("      •  ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
                        count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("        o");
                System.Console.WriteLine("       -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("       • ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("        o");
                System.Console.WriteLine("       -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("        •");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("        o");
                System.Console.WriteLine("       -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
        }
        static void BlastersGraphicDodgeFail()
        {
            int count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("    •  -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("       -|-");
                System.Console.WriteLine("     •  ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("        o");
                System.Console.WriteLine("        |<");
                System.Console.WriteLine("      • ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
                        count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("        o");
                System.Console.WriteLine("       •|<");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("        ☠");
                System.Console.WriteLine("        |<");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
        }
        static void BlastersGraphicDeflectSucess()
        {
            int count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("    • [-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("     •[-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("     *[-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
                        count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("      [-|-");
                System.Console.WriteLine("     *  ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("      [-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("     *   ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("      [-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
        }
        static void BlastersGraphicDeflectFail()
        {
            int count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("    • [-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        o");
                System.Console.WriteLine("     •[-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("      • o");
                System.Console.WriteLine("      [-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
                        count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("       •o");
                System.Console.WriteLine("      [-|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
            count = 0;
            while(count <1)
            {
                Console.Clear();
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("        ☠");
                System.Console.WriteLine("       -|-");
                System.Console.WriteLine("        ^");
                System.Console.WriteLine("         ");
                System.Console.WriteLine("         ");
                count++;
                Delay();
            }
        }
    //End of Blasters Graphics


        static void Delay()
        {
            int millSecondWait= 1000; //1 second delay
            Thread.Sleep(millSecondWait);
        }





    }
}

