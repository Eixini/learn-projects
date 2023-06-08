elements = ["Камень", "Ножницы", "Бумага"]

puts "Выберите вариант: 
      0 - камень,
      1 - ножницы,
      2 - бумага"

selectElement = gets.to_i
computerSelectElement = elements[rand(0..2)].to_i

puts "Вы выбрали: #{elements[selectElement]}"
puts "Компьютер выбрал: #{elements[computerSelectElement]}"

# Проверка на ничью
if selectElement == computerSelectElement
    puts "Ничья!"
end

# Комбинация "Камень - Ножницы", и обратно
if (selectElement.to_i == 0) && (computerSelectElement.to_i == 1)
     puts "Вы выиграли!"
end

if (selectElement.to_i == 1) && (computerSelectElement.to_i == 0)
    puts "Вы проиграли!"
end
# Комбинация "Ножницы - Бумага", и обратно
if (selectElement.to_i == 1) && (computerSelectElement.to_i == 2)
    puts "Вы выиграли!"
end

if (selectElement.to_i == 2) && (computerSelectElement.to_i == 1)
   puts "Вы проиграли!"
end
# Комбинация "Камень - Бумага", и обратно
if (selectElement.to_i == 2) && (computerSelectElement.to_i == 0)
    puts "Вы выиграли!"
end

if (selectElement.to_i == 0) && (computerSelectElement.to_i == 2)
   puts "Вы проиграли!"
end