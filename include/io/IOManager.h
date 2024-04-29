#pragma once

#include <string>
#include <functional>
#include <unordered_map>
#include <memory>
#include <stdexcept>
#include "../enums/SensorTypes.h"
#include "../../Sensor.h"


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



class IOManager : public IIOManager {
private:
    std::unordered_map<SensorTypes, ISensor*> sensors;

public:
    virtual ~IOManager();

    void registerSensor(SensorTypes sensorType, ISensor* sensor);

    std::string readSensorData(SensorTypes sensorType);

    void writeSensorData(SensorTypes sensorType, const std::string& data);
};

