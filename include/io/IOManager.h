#pragma once

#include "SensorTypes.h"
#include <string>
#include <functional>
#include <unordered_map>
#include <memory>
#include <stdexcept>

class ISensor;

class IIOManager {
public:
    virtual ~IIOManager() = default;

    // Register a sensor with the IO manager
    virtual void registerSensor(SensorTypes sensorType, ISensor* sensor) = 0;

    // Read data from a sensor
    virtual std::string readSensorData(SensorTypes sensorType) = 0;

    // Write data to a sensor
    virtual void writeSensorData(SensorTypes sensorType, const std::string& data) = 0;

};

class ISensor {
public:
    virtual ~ISensor() = default;

    // Read data from the sensor
    virtual std::string readData() = 0;

    // Write data to the sensor
    virtual void writeData(const std::string& data) = 0;
};




class IOManager : public IIOManager {
private:
    std::unordered_map<SensorTypes, ISensor*> sensors;

public:
    virtual ~IOManager() override {
        // Proper cleanup if necessary
    }

    void registerSensor(SensorTypes sensorType, ISensor* sensor) override {
        sensors[sensorType] = sensor;
    }

    std::string readSensorData(SensorTypes sensorType) override {
        if (sensors.find(sensorType) != sensors.end()) {
            return sensors[sensorType]->readData();
        }
        throw std::runtime_error("Sensor not found.");
    }

    void writeSensorData(SensorTypes sensorType, const std::string& data) override {
        if (sensors.find(sensorType) != sensors.end()) {
            sensors[sensorType]->writeData(data);
        }
        else {
            throw std::runtime_error("Sensor not found.");
        }
    }
};

