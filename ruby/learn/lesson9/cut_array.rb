def cut_array(arr,quantity)
    return arr.first(quantity)
end

initial_array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

puts "Сколько первых элементов массива нужно?"

quan = gets.chomp.to_i

puts "Выбраны элементы: #{cut_array(initial_array, quan)}"