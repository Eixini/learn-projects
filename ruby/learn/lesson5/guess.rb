guessNumber = rand(16)

puts "Загадано число от 0 до 16, отгадать, какое?"

# Попытка 1
inputNumber = gets.chomp.to_i

if inputNumber == guessNumber
    abort 'Вы выиграли!'
else
    if inputNumber > guessNumber
        puts 'Нужно меньше'
    else
        puts 'Нужно больше'
    end

    if (inputNumber - guessNumber).abs < 3
        puts 'Тепло'
    else
        puts 'Холодно'
    end
end

#Попытка 2
inputNumber = gets.chomp.to_i

if inputNumber == guessNumber
    abort 'Вы выиграли!'
else
    if inputNumber > guessNumber
        puts 'Нужно меньше'
    else
        puts 'Нужно больше'
    end

    if (inputNumber - guessNumber).abs < 3
        puts 'Тепло'
    else
        puts 'Холодно'
    end
end

#Попытка 3
inputNumber = gets.chomp.to_i

if inputNumber == guessNumber
    abort 'Вы выиграли!'
else
    if inputNumber > guessNumber
        puts 'Нужно меньше'
    else
        puts 'Нужно больше'
    end

    if (inputNumber - guessNumber).abs < 3
        puts 'Тепло'
    else
        puts 'Холодно'
    end
end

puts "Не повезло... Было загадано число #{guessNumber.to_s}"