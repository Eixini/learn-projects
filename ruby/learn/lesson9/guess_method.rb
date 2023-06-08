def guess(num, guess_number)
    if num == guess_number
        abort 'Вы выиграли!'
    else
        if num > guess_number
            puts 'Нужно меньше'
        else
            puts 'Нужно больше'
        end
    
        if (num - guess_number).abs < 3
            puts 'Тепло'
        else
            puts 'Холодно'
        end
    end
end

guessNumber = rand(16)

puts "Загадано число от 0 до 16, отгадать, какое?"

# Попытка 1
inputNumber = gets.chomp.to_i
guess(inputNumber,guessNumber)

# Попытка 2
inputNumber = gets.chomp.to_i
guess(inputNumber,guessNumber)

# Попытка 3
inputNumber = gets.chomp.to_i
guess(inputNumber,guessNumber)