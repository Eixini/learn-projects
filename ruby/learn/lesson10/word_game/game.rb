require './methods.rb'

cls

puts "Игра виселица, версия 1"

letters = get_letters 
errors = 0            # Счетчик ошибок
bad_letters = []      # Массив с буквами, которые вввел пользователь, но они отсутсвуют в загаданном слове
good_letters = []     # Массив с буквами, которые вввел пользователь и они присутсвуют в слове

while errors < 7 do
    print_status(letters, good_letters, bad_letters, errors)

    puts "Введите следуюшую букву"

    user_input = get_user_input
    result = check_result(user_input, letters, good_letters, bad_letters)
    
    if(result == -1)
        errors += 1
    elsif(result == 1)
        break
    end
end

print_status(letters, good_letters, bad_letters, errors)
