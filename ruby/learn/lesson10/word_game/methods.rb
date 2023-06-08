# Метод для получения и проверки введенного слова
def get_letters
    word = ARGV[0]

    if (word == nil || word == "")
        abort "Вы не ввели слово для игры!"
    end

    return word.split("")
end

#Метод для получения пользовательского ввода
def get_user_input
    letter = ""

    while letter == "" do
        letter = STDIN.gets.encode("UTF-8").chomp
    end

    return letter
end

#Проверка на наличие введенной буквы в загаданном слове
def check_result(user_input, lettors, good_letters, bad_letters)
    # Проверка на ввод ранее введенной буквы
    if(good_letters.include?(user_input) || bad_letters.include?(user_input))
        return 0
    end

    if lettors.include? user_input
        good_letters << user_input

        # Условие когда отгадано все слово
        if lettors.uniq.size == good_letters.size
            return 1
        else
            return 0
        end
    else
        bad_letters << user_input

        return -1
    end
end

# Вывод ячеек загаданного слова
def get_word_for_print(letters, good_letters)
    result = ""

    for letter in letters
        if good_letters.include? letter
            result += letter + " "
        else
            result += "_ "
        end
    end

    return result
end

# Вывод информации о текущем состоянии игры
def print_status(letters, good_letters, bad_letters, errors)
    puts "\nСлово: #{get_word_for_print(letters, good_letters)}"

    puts "Ошибки: (#{errors}) : #{bad_letters.join(", ")}"

    if errors >= 7
        puts "Вы проиграли"
    else
        if letters.uniq.size == good_letters.size 
            puts "Поздравляем! Вы выиграли! \n\n"
        else
            puts "Осталось попыток: #{(7 - errors).to_s}"
        end
    end
end

#Очищение терминала после запуска программы
def cls
    system "clear" or system "cls"
end