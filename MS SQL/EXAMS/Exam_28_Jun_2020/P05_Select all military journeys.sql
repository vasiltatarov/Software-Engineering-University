USE ColonialJourney

SELECT Id, FORMAT(JourneyStart, 'dd/MM/yyyy') AS [JourneyStart], FORMAT(JourneyEnd, 'dd/MM/yyyy') AS [JourneyEnd]
FROM Journeys
WHERE Purpose LIKE 'Military'
ORDER BY [JourneyStart]