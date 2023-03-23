/**
 * Bootstrap Table Hungarian translation
 * Author: Nagy Gergely <info@nagygergely.eu>
 */

$.fn.bootstrapTable.locales['hu-HU'] = $.fn.bootstrapTable.locales['hu'] = {
  formatCopyRows () {
    return 'Copy Rows'
  },
  formatPrint () {
    return 'Print'
  },
  formatLoadingMessage () {
    return 'Betöltés, kérem várjon'
  },
  formatRecordsPerPage (pageNumber) {
    return `${pageNumber} rekord per oldal`
  },
  formatShowingRows (pageFrom, pageTo, totalRows, totalNotFiltered) {
    if (totalNotFiltered !== undefined && totalNotFiltered > 0 && totalNotFiltered > totalRows) {
      return `Megjelenítve ${pageFrom} - ${pageTo} / ${totalRows} összesen (filtered from ${totalNotFiltered} total rows)`
    }

    return `Megjelenítve ${pageFrom} - ${pageTo} / ${totalRows} összesen`
  },
  formatSRPaginationPreText () {
    return 'Előző oldal'
  },
  formatSRPaginationPageText (page) {
    return ` ${page} oldalra`
  },
  formatSRPaginationNextText () {
    return 'következő oldal'
  },
  formatDetailPagination (totalRows) {
    return `Oldalak száma: ${totalRows} sor`
  },
  formatClearSearch () {
    return 'Keresés törlése'
  },
  formatSearch () {
    return 'Keresés'
  },
  formatNoMatches () {
    return 'Nincs találat'
  },
  formatPaginationSwitch () {
    return 'Lapozó elrejtése/megjelenítése'
  },
  formatPaginationSwitchDown () {
    return 'Lapozó megjelenítése'
  },
  formatPaginationSwitchUp () {
    return 'Lapozó elrejtése'
  },
  formatRefresh () {
    return 'Frissítés'
  },
  formatToggleOn () {
    return 'Kártya nézet megjelenítése'
  },
  formatToggleOff () {
    return 'Kártyanézet elrejtése'
  },
  formatColumns () {
    return 'Oszlopok'
  },
  formatColumnsToggleAll () {
    return 'Összes kiválasztása'
  },
  formatFullscreen () {
    return 'Teljesképernyő'
  },
  formatAllRows () {
    return 'Összes'
  },
  formatAutoRefresh () {
    return 'Auto frissítés'
  },
  formatExport () {
    return 'Exportálás'
  },
  formatJumpTo () {
    return 'Ugrás'
  },
  formatAdvancedSearch () {
    return 'Bővített keresés'
  },
  formatAdvancedCloseButton () {
    return 'Bezárás'
  },
  formatFilterControlSwitch () {
    return 'Kontrol elrejtés/megjelenítés'
  },
  formatFilterControlSwitchHide () {
    return 'Kontrol elrejtése'
  },
  formatFilterControlSwitchShow () {
    return 'Kontrol megjelenítése'
  }
}

$.extend($.fn.bootstrapTable.defaults, $.fn.bootstrapTable.locales['hu-HU'])
