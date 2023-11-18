import random
import psycopg2
from psycopg2 import Error


import psycopg2
from psycopg2 import Error


try:
    # Подключение к существующей базе данных
    db = psycopg2.connect(user="postgres",
                                  # пароль, который указали при установке PostgreSQL
                                  password="postgres",
                                  host="127.0.0.1",
                                  port="5432",
                                  database="softspace")

    # Курсор для выполнения операций с базой данных
    cursor = db.cursor()
    # Распечатать сведения о PostgreSQL
    print("Информация о сервере PostgreSQL")
    print(db.get_dsn_parameters(), "\n")

  #  record = db.fetchone()
 # print("Вы подключены к - ", record, "\n")


    cursor.execute ("INSERT INTO users(" + " id ,first_name, second_name, login, password, mail)  " + 
        "VALUES ( 1,"+
                    "'"+ "igor"      + "'," +
                    "'"+"popov"     + "'," +
                    "lower('"+"admin"      + "'),"+
                    "crypt('"+"q"     + "', gen_salt('bf', 8)),"+
                    "'"+"igor@mail.ru"      +"@mail.ru')")
    
    record = db.fetchone()
    cursor.execute("INSERT INTO user_role (id_user, id_role) VALUES(1,2)")
    record = db.fetchone()
    print('5%')
    for i in range(2,1000000):
    
        cursor.execute ("INSERT INTO users(id," + "first_name, second_name, login, password, mail)  " + 
        "VALUES ("+str(i)+ " ," +
                    "'"+ "f_name_"+     str(i)      + "'," +
                    "'"+"s_name"+       str(i)      + "'," +
                    "lower('"+"test"+   str(i)      + "'),"+
                    "crypt('"+"test"+   str(i)      + "', gen_salt('bf', 8)),"+
                    "'"+"test"+         str(i)      +"@mail.ru')")
    print('25%')
    record = db.fetchone()
    #test team 
    cursor.execute("INSERT INTO developers(id,name_of_company) VALUES (1,'TestCompany')")
    print('30%')
    record = db.fetchone()
    cursor.execute("INSERT INTO user_dev(id_user, id_dev) VALUES (1, 1)")
    print('35%')
    record = db.fetchone()
    for i in range(1,2000):
        cursor.execute( "INSERT INTO product(id,name, description, id_dev, id_category, price) "+
                "VALUES ("+str(i)+",'Game_Adventure"+str(i)+"','Game Adventure',1 ,"+str(1) +",'"+str(random.randint(50,5000))+".00' )")
    print('55%')
    record = db.fetchone()

    k=0
    for i in range(1,144000):
        id_user = i
        if(i % 200):
            print( str(float(i/1000000)*100) + ' %')
        cursor.execute("INSERT INTO deal (id_user, date_deal, total_price) "+
            "VALUES (" +str(id_user)+", now(), "+"0.00"+")")
        deal =   str(db.one("select id from deal where id_user = "+ str(id_user)))
        print(deal)
        j = random.randint(8,10)
        for h in range (1, j):
            k=k+1
            id_product= random.randint(1,1999)
            
            price = str(db.one("select price  from product WHERE product.id = " + str(id_product)))
            cursor.execute("INSERT INTO deal_product(id_deal, id_product, price) VALUES ("+str(deal)+", "+str(id_product)+",'"+ price+"')")
            deal_p = str(db.one("select id from deal_product where id_deal = "+ str(deal) + "  ORDER BY id DESC limit 1"))
            cursor.execute("INSERT INTO baggage(id_user, id_deal_product)"+
                "VALUES ("+str(id_user)+", "+str(deal_p)+")")
            
        total_price = int(db.one("select sum(price) from deal_product inner join deal on deal_product.id_deal = deal.id WHERE id_deal = " +str(deal) ))
        cursor.execute("UPDATE deal SET  total_price="+str(total_price)+" WHERE deal.id = " +  str(deal))

except (Exception, Error) as error:
    print("Ошибка при работе с PostgreSQL", error)

    # if db != None:
    #     cursor.close()
    #     db.close()
    #     print("Соединение с PostgreSQL закрыто")