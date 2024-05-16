#include <vector>
#include <iostream>
#include <cstdlib> 
#include <ctime>   
#include <cmath>

class DepthMatrix {
private:
    std::vector<std::vector<float>> matrix;
    size_t rows, cols;

public:
    // initialize matrix size and allocate memory
    DepthMatrix(size_t rows, size_t cols) : rows(rows), cols(cols) {
        matrix.resize(rows, std::vector<float>(cols, 0));
    }


    void setValue(size_t row, size_t col, float value) {
        if (row < rows && col < cols) {
            matrix[row][col] = value;
        }
    }


    float getValue(size_t row, size_t col) const {
        if (row < rows && col < cols) {
            return matrix[row][col];
        }
        return -1; // out of bounds
    }


    // Populate the matrix with a ball shape in the center
    void populateWithDummyData() {
        size_t centerX = cols / 2;
        size_t centerY = rows / 2;
        float radius = std::min(rows, cols) / 4.0;

        for (size_t y = 0; y < rows; ++y) {
            for (size_t x = 0; x < cols; ++x) {
                float distance = std::sqrt(std::pow(x - centerX, 2) + std::pow(y - centerY, 2));
                if (distance <= radius) {
                    setValue(y, x, 1); // Inside the ball
                }
                else {
                    setValue(y, x, 0); // Outside the ball
                }
            }
        }
    }
    // Convert the matrix to string (for debugging)
    std::string toString() const {
        std::string data;
        for (const auto& row : matrix) {
            for (float val : row) {
                data += std::to_string(val) + " ";
            }
            data += "\n";
        }
        return data;
    }


    size_t getRows() const {
        return rows;
    }

    size_t getCols() const {
        return cols;
    }

};
