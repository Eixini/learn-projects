puts "Добро пожаловать! Пожалуйста, выберите один из следующих языков программирования:
            1. C++
            2. C#
            3. Ruby"
choice = nil

until (1..3).include?(choice) do
    choice = gets.to_i
end

puts "Вы выбрали пункт: #{choice}"