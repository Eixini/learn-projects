def shooting_star(count)
    star_array = ""

    iter = 0

    while iter < count
        star_array += "*"
        iter += 1
    end

    puts "Звезды: #{star_array}"
end

puts "Сколько нужно звезд?"

star_count = gets.chomp.to_i

shooting_star(star_count)