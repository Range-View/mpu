#include <vector>
#include <iostream>
#include <cstdlib> 
#include <ctime>   

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


    void populateWithDummyData() {
        srand(time(NULL)); // random number
        for (size_t i = 0; i < rows; ++i) {
            for (size_t j = 0; j < cols; ++j) {
                float dummyValue = static_cast<float>(rand() % 100);
                setValue(i, j, dummyValue);
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
